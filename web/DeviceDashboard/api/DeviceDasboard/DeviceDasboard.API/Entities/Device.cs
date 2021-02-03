using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeviceDashboard.API.Entities
{
    public class Device
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public ICollection<Reading> Readings { get; set; }  = new List<Reading>();    

    

        /*public ICollection<Course> Courses { get; set; }
            = new List<Course>();*/
    }
}
