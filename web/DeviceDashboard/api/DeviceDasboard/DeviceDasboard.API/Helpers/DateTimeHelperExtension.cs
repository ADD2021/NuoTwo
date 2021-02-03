using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceDasboard.API.Helpers
{
    public static class DateTimeHelperExtension
    {
        public static DateTime ConvertToDateTime(this long createdAt)
        {
            return new DateTime(createdAt);
        }
    }
}
