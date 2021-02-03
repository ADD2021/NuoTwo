using DeviceDasboard.API.ResourceParameters;
using DeviceDashboard.API.DbContexts;
using DeviceDashboard.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDashboard.API.Services
{
    public class DeviceDashboardRepository : IDeviceDashboardRepository, IDisposable
    {
        private readonly DeviceDashboardContext _context;

        public DeviceDashboardRepository(DeviceDashboardContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adds reading to database
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="reading"></param>
       public async Task AddReading(Guid deviceId, Reading reading)
        {
            if (deviceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            if (reading == null)
            {
                throw new ArgumentNullException(nameof(reading));
            }
            // always set the AuthorId to the passed-in authorId
            reading.DeviceId = deviceId;
            await _context.Readings.AddAsync(reading); 
        } 
        
        /// <summary>
        /// Deletes reading from database
        /// </summary>
        /// <param name="reading"></param>
        public void DeleteReading(Reading reading)
        {
            _context.Readings.Remove(reading);
        }
        
        /// <summary>
        /// Gets reading for specific device from database
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="readingId"></param>
        /// <returns>Reading from database</returns>
        public async Task<Reading> GetReading(Guid deviceId, Guid readingId)
        {
            if (deviceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            if (readingId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(readingId));
            }

            return await _context.Readings
              .Where(r => r.DeviceId == deviceId && r.Id == readingId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Gets all readings for one device
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns>List of readings</returns>
        public async Task<IEnumerable<Reading>> GetReadings(Guid deviceId)
        {
            if (deviceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            return await _context.Readings
                        .Where(r => r.DeviceId == deviceId)
                        .OrderBy(r => r.CreatedAt).ToListAsync();
        }

        /// <summary>
        /// Updates reading
        /// </summary>
        /// <param name="reading"></param>
        public void UpdateReading(Reading reading)
        {
            // no code in this implementation
        } 

        /// <summary>
        /// Adds device to database
        /// </summary>
        /// <param name="device"></param>
        public async Task AddDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            // the repository fills the id (instead of using identity columns)
            device.Id = Guid.NewGuid();

            foreach (var reading in device.Readings)
            {
                reading.Id = Guid.NewGuid();
            }

           await _context.Devices.AddAsync(device);
        } 

        /// <summary>
        /// Checks if device exists
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns>True if exists, false if doesn't</returns>
        public async Task<bool> DeviceExists(Guid deviceId)
        {
            if (deviceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            return await _context.Devices.AnyAsync(d => d.Id == deviceId);
        }
        
        /// <summary>
        /// Deletes device and all the readings for that device from database
        /// </summary>
        /// <param name="device"></param>
        public void DeleteDevice(Device device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            _context.Devices.Remove(device);
        }
        
        /// <summary>
        /// Gets specific device from database
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns>Found device from database</returns>
        public async Task<Device> GetDevice(Guid deviceId)
        {
            if (deviceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(deviceId));
            }

            return await  _context.Devices.FirstOrDefaultAsync(d => d.Id == deviceId);
        }

        //dodati i za Readings...
        /// <summary>
        /// Gets devices by filtering and searching parameters
        /// </summary>
        /// <param name="devicesResourceParameters"></param>
        /// <returns>Found device from database</returns>
        public async Task<IEnumerable<Device>> GetDevices(DevicesResourceParameters devicesResourceParameters)
        {
            if (devicesResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(devicesResourceParameters));
            }
            if (string.IsNullOrWhiteSpace(devicesResourceParameters.Address) && string.IsNullOrWhiteSpace(devicesResourceParameters.SearchQuery))
            {
                return await GetDevices();
            }
            var collection = _context.Devices as IQueryable<Device>;
            if (!string.IsNullOrWhiteSpace(devicesResourceParameters.Address))
            {
                devicesResourceParameters.Address = devicesResourceParameters.Address.Trim();
                collection = collection.Where(d => d.Address == devicesResourceParameters.Address);
            }
            if (!string.IsNullOrWhiteSpace(devicesResourceParameters.SearchQuery))
            {
                devicesResourceParameters.SearchQuery = devicesResourceParameters.SearchQuery.Trim();
                collection = collection.Where(d => d.Address.Contains(devicesResourceParameters.SearchQuery));
            }
            return await collection.ToListAsync();
        }

        /// <summary>
        /// Gets all devices from database
        /// </summary>
        /// <returns>List of devices</returns>
        public async Task<IEnumerable<Device>> GetDevices()
        {
            return await _context.Devices.ToListAsync<Device>();
        }
         
    
        /// <summary>
        /// Updates device
        /// </summary>
        /// <param name="device"></param>
        public void UpdateDevice(Device device)
        {
            // no code in this implementation
        }

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

      
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
