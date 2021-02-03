using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Devices
{
    class AddEditDeviceViewModel : BindableBase
    {
        private IDevicesRepository _repo;

        public AddEditDeviceViewModel(IDevicesRepository repo)
        {
            _repo = repo;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private bool _EditMode;

        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private SimpleEditableDevice _Device;

        public SimpleEditableDevice Device
        {
            get { return _Device; }
            set { SetProperty(ref _Device, value); }
        }


        private Device _editingDevice = null;

        public void SetDevice(Device cust)
        {
            _editingDevice = cust;
            if (Device != null) Device.ErrorsChanged -= RaiseCanExecuteChanged;
            Device = new SimpleEditableDevice();
            Device.ErrorsChanged += RaiseCanExecuteChanged;
            CopyDevice(cust, Device);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyDevice(Device source, SimpleEditableDevice target)
        {
            target.Id = source.Id;
            if (EditMode)
            {
                target.Address = source.Address;
                
            }
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateDevice(Device, _editingDevice);
            if (EditMode)
                await _repo.UpdateDeviceAsync(_editingDevice);
            else
                await _repo.AddDeviceAsync(_editingDevice);
            Done();
        }

        private void UpdateDevice(SimpleEditableDevice source, Device target)
        {
            target.Address = source.Address;
           
        }

        bool CanSave()
        {
            return !Device.HasErrors;
        }
    }
}
