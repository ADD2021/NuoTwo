using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Services
{
    public class DevicesRepository : IDevicesRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public Task<List<Device>> GetDevicesAsync()
        {
            return _context.Devices.ToListAsync();
        }

        public Task<Device> GetDeviceAsync(Guid id)
        {
            return _context.Devices.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Device> AddDeviceAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Device> UpdateDeviceAsync(Device device)
        {
            if (!_context.Devices.Local.Any(c => c.Id == device.Id))
            {
                _context.Devices.Attach(device);
            }
            _context.Entry(device).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return device;

        }

        public async Task DeleteDeviceAsync(Guid deviceId)
        {
            var device = _context.Devices.FirstOrDefault(c => c.Id == deviceId);
            if (device != null)
            {
                _context.Devices.Remove(device);
            }
            await _context.SaveChangesAsync();
        }
    }
}
