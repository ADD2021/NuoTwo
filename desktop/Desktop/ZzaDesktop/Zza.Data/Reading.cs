using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class Reading
    {
        public Reading()
        {
           
        }
        [Key]
        public long Id { get; set; }
        public Guid DeviceId { get; set; }

        public int CO2Consumption { get; set; }

        public int O2Production{ get; set; }
        
        public long CreatedAt { get; set; }


        //public Customer Customer { get; set; }

    }
}
