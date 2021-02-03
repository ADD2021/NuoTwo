 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.ResourceParameters
{
    /// <summary>
    /// Resource parameters for Device filtering and searching
    /// </summary>
    public class DevicesResourceParameters
    {
        public string Address { get; set; }
        public string SearchQuery { get; set; }
    }
}
