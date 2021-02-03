using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Models
{
    /// <summary>
    /// Abstract class for manipulating creation and deletion
    /// </summary>
    public abstract class DeviceForManipulationDTO
    {
        [Required]
        public string Address { get; set; }
    }
}
