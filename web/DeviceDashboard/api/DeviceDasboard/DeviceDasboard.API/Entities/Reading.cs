using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceDashboard.API.Entities
{
    public class Reading
    {
        [Key]       
        public Guid Id { get; set; }

        [Required]
        public long CreatedAt { get; set; }

        [Required]
        public int CO2Consumption { get; set; }

        [Required]
        public int O2Production { get; set; }

        [ForeignKey("DeviceId")]
        public Device Device { get; set; }

        public Guid DeviceId { get; set; }
        
       
    }
}
