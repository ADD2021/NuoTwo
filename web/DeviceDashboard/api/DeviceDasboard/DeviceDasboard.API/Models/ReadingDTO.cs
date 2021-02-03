using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Models
{

    /// <summary>
    /// DTO class that represents Reading
    /// </summary>
    public class ReadingDTO
    {
        
        public Guid Id { get; set; }

        public long CreatedAt { get; set; }

        public int CO2Consumption { get; set; }

        public int O2Production { get; set; }

        public Guid DeviceId { get; set; }
    }
}
