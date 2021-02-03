using DeviceDasboard.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.ValidationAttributes
{
    /// <summary>
    /// Validation attribute (object) for CO2 > O2.
    /// </summary>
    public class ReadingCO2MustBeGreaterThan02 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var reading = (ReadingForManipulationDTO) validationContext.ObjectInstance;

            if (reading.CO2Consumption <= reading.O2Production)
            {
                 return new ValidationResult(ErrorMessage, new[] { nameof(ReadingForCreationDTO) });
            }
            return ValidationResult.Success;
        }
    }
}
