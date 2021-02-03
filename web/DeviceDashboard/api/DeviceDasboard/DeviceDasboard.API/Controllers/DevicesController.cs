
using AutoMapper;
using DeviceDasboard.API.Models;
using DeviceDashboard.API.Entities;
using DeviceDashboard.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceDashboardRepository _deviceDashboardRepository;
        private readonly IMapper _mapper;

        public DevicesController(IDeviceDashboardRepository deviceDashboardRepository, IMapper mapper)
        {
            _deviceDashboardRepository = deviceDashboardRepository ?? throw new ArgumentNullException(nameof(deviceDashboardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// Gets all devices
        /// </summary>
        /// <returns>All devices from database</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetDevices()
        {
            var devicesFromRepo = await _deviceDashboardRepository.GetDevices();
            foreach(Device device in devicesFromRepo)
            {
                var readingsFromRepo = await _deviceDashboardRepository.GetReadings(device.Id);
                if (readingsFromRepo == null)
                {
                    return NotFound();
                }
                ICollection <Reading> readings = new List<Reading>();
                if (readingsFromRepo.Count() >0) 
                readings.Add(readingsFromRepo.Last());
                device.Readings = readings;
            }
            return Ok(_mapper.Map<IEnumerable<DeviceDTO>>(devicesFromRepo));
        }

        /// <summary>
        /// Gets a device by given id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns>Device in database by given id</returns>
        [HttpGet("{deviceId}", Name = "GetDevice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeviceDTO>> GetDevice(Guid deviceId)
        {
            var deviceFromRepo = await _deviceDashboardRepository.GetDevice(deviceId);
            if (deviceFromRepo == null )
            {
                return NotFound();
            }
            var readingsFromRepo = await _deviceDashboardRepository.GetReadings(deviceId);
            if (readingsFromRepo == null)
            {
                return NotFound();
            }

            
            var devicesForReturn = _mapper.Map<DeviceDTO>(deviceFromRepo);
            return Ok(devicesForReturn);
        }

        /// <summary>
        /// Creates new device
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        POST /devices
        ///        {
        ///          "address": "Maksimirska 65"
        ///        }
        ///        
        /// </remarks>
        /// <param name="device"></param>
        /// <returns>Newly created device</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DeviceDTO>> CreateDevice(DeviceForCreationDTO device)
        {
            var deviceEntity = _mapper.Map<Device>(device);
            await _deviceDashboardRepository.AddDevice(deviceEntity);
            await _deviceDashboardRepository.Save();
            var deviceForReturn = (_mapper.Map<DeviceDTO>(deviceEntity));
            return CreatedAtRoute("GetDevice", new
            {
              deviceId = deviceForReturn.Id
            }, deviceForReturn);


        }

        /// <summary>
        /// Upserts device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="device"></param>
        /// <returns>No content or CreatedAt</returns>
        [HttpPut("{deviceId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DeviceDTO>> UpdateDevice(Guid deviceId, DeviceForUpdateDTO device)
        {

        
            var deviceFromRepo = await _deviceDashboardRepository.GetDevice(deviceId);
            if (deviceFromRepo == null)
            {
                var deviceToAdd = _mapper.Map<Device>(device);
                deviceToAdd.Id = deviceId;
                await _deviceDashboardRepository.AddDevice(deviceToAdd);
                await _deviceDashboardRepository.Save();
                var deviceForReturn = _mapper.Map<DeviceDTO>(deviceToAdd);
                return CreatedAtRoute("GetDevice", new
                {
                    deviceId = deviceForReturn.Id
                }, deviceForReturn);

            }

            _mapper.Map(device, deviceFromRepo);
             _deviceDashboardRepository.UpdateDevice(deviceFromRepo);
            await  _deviceDashboardRepository.Save();

            return Ok(_mapper.Map<DeviceDTO>(deviceFromRepo));

        }

        /// <summary>
        /// Partially upserts device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="patchDocument"></param>
        /// <returns>Error or no content or created device</returns>
        [HttpPatch("{deviceId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Device>> PartiallyUpdateDevice(Guid deviceId, JsonPatchDocument<DeviceForUpdateDTO> patchDocument)
        {

          
            var deviceFromRepo = await _deviceDashboardRepository.GetDevice(deviceId);
            if (deviceFromRepo == null)
            {
                var deviceDto = new DeviceForUpdateDTO();
                patchDocument.ApplyTo(deviceDto, ModelState);
                if (!TryValidateModel(deviceDto))
                {
                    return ValidationProblem(ModelState);
                }
                var deviceToAdd = _mapper.Map<Device>(deviceDto);
                deviceToAdd.Id = deviceId;
                await _deviceDashboardRepository.AddDevice(deviceToAdd);
                await  _deviceDashboardRepository.Save();
                var deviceForReturn = _mapper.Map<DeviceDTO>(deviceToAdd);
                return CreatedAtRoute("GetDevice", new
                {
                    deviceId = deviceForReturn.Id
                }, deviceForReturn);
            }
            var deviceToPatch = _mapper.Map<DeviceForUpdateDTO>(deviceFromRepo);
            patchDocument.ApplyTo(deviceToPatch, ModelState);
            if (!TryValidateModel(deviceToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(deviceToPatch, deviceFromRepo);
             _deviceDashboardRepository.UpdateDevice(deviceFromRepo);
            await _deviceDashboardRepository.Save();
            return Ok(_mapper.Map<DeviceDTO>(deviceFromRepo));


        }

     
        /// <summary>
        /// Deletes device and its readings.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns> No Content</returns>
        [HttpDelete("{deviceId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteDevice(Guid deviceId)
        {
            var deviceFromRepo = await _deviceDashboardRepository.GetDevice(deviceId);

            if (deviceFromRepo == null)
            {
                return NotFound();
            }

            _deviceDashboardRepository.DeleteDevice(deviceFromRepo);

            await _deviceDashboardRepository.Save();

            return NoContent();
        }

        /// <summary>
        /// Writes full message when validation problem occures.
        /// </summary>
        /// <param name="modelStateDictionary"></param>
        /// <returns>Message</returns>
        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);

        }
    }
}