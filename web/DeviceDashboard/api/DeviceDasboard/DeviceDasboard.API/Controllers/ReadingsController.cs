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
using System.Threading.Tasks;

namespace DeviceDasboard.API.Controllers
{
    [ApiController]
    [Route("api/devices/{deviceId}/readings")]
    public class ReadingsController : ControllerBase
    {
        private readonly IDeviceDashboardRepository _deviceDashboardRepository;
        private readonly IMapper _mapper;

        public ReadingsController(IDeviceDashboardRepository courseLibraryRepository, IMapper mapper)
        {
            _deviceDashboardRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets readings for specific device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns>Reading for device from database</returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ReadingDTO>>> GetReadings(Guid deviceId)
        {
            if (! await _deviceDashboardRepository.DeviceExists(deviceId))
            {
                return NotFound();
            }
            var readingsFromRepo = await _deviceDashboardRepository.GetReadings(deviceId);
            return Ok(_mapper.Map<IEnumerable<ReadingDTO>>(readingsFromRepo));
        }

        /// <summary>
        /// Gets specific reading for specific device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="readingId"></param>
        /// <returns>Reading from database</returns>
        [HttpGet("{readingId}", Name = "GetReading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadingDTO>> GetReading(Guid deviceId, Guid readingId)
        {
            if (! await _deviceDashboardRepository.DeviceExists(deviceId))
            {
                return NotFound();
            }

            var readingFromRepo = await _deviceDashboardRepository.GetReading(deviceId, readingId);
            if (readingFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadingDTO>(readingFromRepo));
        }

        /// <summary>
        /// Creates new reading for device
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///        POST /devices/{deviceId}/readings
        ///        {
        ///          "createdAt": "1604448000",
        ///          "CO2Consumption": "17",
        ///          "O2Production": "13"
        ///        }
        ///        
        /// </remarks>
        /// <param name="deviceId"></param>
        /// <param name="reading"></param>
        /// <returns>Newly created reading</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReadingDTO>> CreateReading(Guid deviceId, ReadingForCreationDTO reading)
        {
            if (! await _deviceDashboardRepository.DeviceExists(deviceId))
            {
                return NotFound();
            }
            var readingEntitiy = _mapper.Map<DeviceDashboard.API.Entities.Reading>(reading);
            await _deviceDashboardRepository.AddReading(deviceId, readingEntitiy);
            await _deviceDashboardRepository.Save();
            var readingForReturn = _mapper.Map<ReadingDTO>(readingEntitiy);
            return CreatedAtRoute("GetReading", new
            {
                deviceId = deviceId,
                readingId = readingForReturn.Id
            }, readingForReturn);


        }
        /// <summary>
        /// Upserts reading
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="readingId"></param>
        /// <param name="reading"></param>
        /// <returns>No content for successful update, new Reading for Upsert and Not Found if error</returns>
        [HttpPut("{readingId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ReadingDTO>> UpdateReading(Guid deviceId, Guid readingId, ReadingForUpdateDTO reading)
        {

            if (! await _deviceDashboardRepository.DeviceExists(deviceId))
            {
                return NotFound();
            }
            var readingFromRepo = await _deviceDashboardRepository.GetReading(deviceId, readingId);
            if (readingFromRepo == null)
            {
                var readingToAdd = _mapper.Map<Reading>(reading);
                readingToAdd.Id = readingId;
                await _deviceDashboardRepository.AddReading(deviceId, readingToAdd);
                await  _deviceDashboardRepository.Save();
                var readingForReturn = _mapper.Map<ReadingDTO>(readingToAdd);
                return CreatedAtRoute("GetReading", new
                {
                    deviceId,
                    readingId = readingForReturn.Id
                }, readingForReturn);

            }

            _mapper.Map(reading, readingFromRepo);
             _deviceDashboardRepository.UpdateReading(readingFromRepo);
            await _deviceDashboardRepository.Save();

            return Ok(_mapper.Map<ReadingDTO>(readingFromRepo));

        }



        /// <summary>
        /// Partially upserts specific reading
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="readingId"></param>
        /// <param name="patchDocument"></param>
        /// <returns>Error, created new reading or no content if successfully updated</returns>
        [HttpPatch("{readingId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReadingDTO>> PartiallyUpdateReading(Guid deviceId, Guid readingId, JsonPatchDocument<ReadingForUpdateDTO> patchDocument)
        {

            if (! await _deviceDashboardRepository.DeviceExists(deviceId))
            {
                return NotFound();
            }
            var readingFromRepo = await  _deviceDashboardRepository.GetReading(deviceId, readingId);
            if (readingFromRepo == null)
            {
                var readingDto = new ReadingForUpdateDTO();
                patchDocument.ApplyTo(readingDto, ModelState);
                if (!TryValidateModel(readingDto))
                {
                    return ValidationProblem(ModelState);
                }
                var readingToAdd = _mapper.Map<Reading>(readingDto);
                readingToAdd.Id = readingId;
                await _deviceDashboardRepository.AddReading(deviceId, readingToAdd);
                 await _deviceDashboardRepository.Save();
                var readingForReturn = _mapper.Map<ReadingDTO>(readingToAdd);
                return CreatedAtRoute("GetReading", new
                {
                    deviceId,
                    readingId = readingForReturn.Id
                }, readingForReturn);
            }
            var readingToPatch = _mapper.Map<ReadingForUpdateDTO>(readingFromRepo);
            patchDocument.ApplyTo(readingToPatch, ModelState);
            if (!TryValidateModel(readingToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(readingToPatch, readingFromRepo);
            _deviceDashboardRepository.UpdateReading(readingFromRepo);
            await _deviceDashboardRepository.Save();
            return Ok(_mapper.Map<ReadingDTO>(readingFromRepo));


        }
        /// <summary>
        /// Deletes specific reading
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="readingId"></param>
        /// <returns>Error or no content</returns>
        [HttpDelete("{readingId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteReading(Guid deviceId, Guid readingId)
        {
            if (! await _deviceDashboardRepository.DeviceExists(deviceId))
            {
                return NotFound();
            }

            var readingFromRepo = await _deviceDashboardRepository.GetReading(deviceId, readingId);
            if (readingFromRepo == null)
            {
                return NotFound();
            }
            _deviceDashboardRepository.DeleteReading(readingFromRepo);
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