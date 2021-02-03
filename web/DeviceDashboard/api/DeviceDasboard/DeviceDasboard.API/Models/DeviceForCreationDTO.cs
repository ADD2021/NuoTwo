using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Models
{
    /// <summary>
    /// DTO creation Device class
    /// </summary>
    public class DeviceForCreationDTO : DeviceForManipulationDTO
    {
        public ICollection<ReadingForCreationDTO> Readings { get; set; } = new List<ReadingForCreationDTO>();
    }
}
