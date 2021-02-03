using DeviceDasboard.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Models
{
    /// <summary>
    /// Abstract class for manipulating update and create for reading
    /// </summary>
    [ReadingCO2MustBeGreaterThan02(ErrorMessage = "The provided CO2 consumption should be greater than 02 production.")]

    public abstract class ReadingForManipulationDTO
    {
        [Required(ErrorMessage = "You should fill out a created at")]
        public long CreatedAt { get; set; }

        [Required(ErrorMessage = "You should fill out a CO2 consumption")]
        public int CO2Consumption { get; set; }

        [Required(ErrorMessage = "You should fill out a O2 production")]
        public int O2Production { get; set; }
    }
}
