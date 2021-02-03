using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Services
{
    public interface IDevicesRepository
    {
        Task<List<Device>> GetDevicesAsync();
        Task<Device> GetDeviceAsync(Guid id);
        Task<Device> AddDeviceAsync(Device device);
        Task<Device> UpdateDeviceAsync(Device device);
        Task DeleteDeviceAsync(Guid deviceId);
    }
}
