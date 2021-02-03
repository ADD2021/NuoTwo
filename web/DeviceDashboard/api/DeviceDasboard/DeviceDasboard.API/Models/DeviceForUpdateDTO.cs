using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Models
{
    /// <summary>
    /// Device for update class
    /// </summary>
    public class DeviceForUpdateDTO : DeviceForManipulationDTO
    {
        public ICollection<ReadingForUpdateDTO> Readings { get; set; } = new List<ReadingForUpdateDTO>();
    }
}
