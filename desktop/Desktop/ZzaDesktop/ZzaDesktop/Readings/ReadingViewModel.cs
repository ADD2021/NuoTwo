using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDesktop.Readings

{
    class ReadingViewModel : BindableBase
    {
        private Guid _DeviceId;

        public Guid DeviceId
        {
            get { return _DeviceId; }
            set { SetProperty(ref _DeviceId, value); }
        }
    }
}
