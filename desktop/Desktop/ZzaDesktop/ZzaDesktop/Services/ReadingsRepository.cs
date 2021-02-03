using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Zza.Data;
namespace ZzaDesktop.Services
{
    public class ReadingsRepository : IReadingsRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public async Task<List<Reading>> GetReadingsForDevicesAsync(Guid deviceId)
        {
            return await _context.Readings.Where(o => o.DeviceId == deviceId).ToListAsync();
        }

        public async Task<List<Reading>> GetAllReadingsAsync()
        {
            return await _context.Readings.ToListAsync();
        }

        public async Task<Reading> AddReadingsAsync(Reading reading)
        {
            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();
            return reading;
        }

        public async Task<Reading> UpdateReadingsAsync(Reading reading)
        {
            if (!_context.Readings.Local.Any(o => o.Id == reading.Id))
            {
                _context.Readings.Attach(reading);
            }
            _context.Entry(reading).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return reading;
        }

        public async Task DeleteReadingAsync(int readingId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var order = _context.Readings.FirstOrDefault(o => o.Id == readingId);
                if (order != null)
                {

                    _context.Readings.Remove(order);
                }
                await _context.SaveChangesAsync();
                scope.Complete();
            }
        }



    }
}
