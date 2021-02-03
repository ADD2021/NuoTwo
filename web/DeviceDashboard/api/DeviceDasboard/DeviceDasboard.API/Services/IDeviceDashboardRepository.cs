using DeviceDasboard.API.ResourceParameters;
using DeviceDashboard.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceDashboard.API.Services
{
    public interface IDeviceDashboardRepository
    {    
        Task<IEnumerable<Reading>> GetReadings(Guid deviceId);
        Task<Reading> GetReading(Guid deviceId, Guid readingId);
        Task AddReading(Guid deviceId, Reading reading);
        void UpdateReading(Reading reading);
        void DeleteReading(Reading reading);
        Task<IEnumerable<Device>> GetDevices();
        Task<Device> GetDevice(Guid deviceId);
  
        Task AddDevice(Device device);
      
        void DeleteDevice(Device device);
        void UpdateDevice(Device device); 
        Task<bool> DeviceExists(Guid deviceId); 
        Task<bool> Save();
        public Task<IEnumerable<Device>> GetDevices(DevicesResourceParameters devicesResourceParameters);

    }
}
