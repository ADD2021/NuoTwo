using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zza.Data;

namespace ZzaDesktop.Services
{
    public interface IReadingsRepository
    {
        Task<List<Reading>> GetReadingsForDevicesAsync(Guid deviceId);
        Task<List<Reading>> GetAllReadingsAsync();
        Task<Reading> AddReadingsAsync(Reading reading);
        Task<Reading> UpdateReadingsAsync(Reading reading);
        Task DeleteReadingAsync(int readingId);

     
    }
}
