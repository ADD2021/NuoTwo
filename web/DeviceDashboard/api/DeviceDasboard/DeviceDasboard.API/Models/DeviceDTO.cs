 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Models
{
    /// <summary>
    /// Device DTO class
    /// </summary>
    public class DeviceDTO
    {
        public Guid Id { get; set; }

        public string Address { get; set; }

        public ICollection<ReadingDTO> Readings { get; set; } = new List<ReadingDTO>();
    }
}
