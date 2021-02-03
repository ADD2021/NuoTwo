using System;
using System.Linq;
using Zza.Data;
using ZzaDesktop.Devices;
using ZzaDesktop.ReadingPrep;
using ZzaDesktop.Readings;
using ZzaDesktop.Services;
using Unity;

namespace ZzaDesktop
{
    class MainWindowViewModel : BindableBase
    {
        private DeviceListViewModel _deviceListViewModel;
        private ReadingViewModel _readingViewModel = new ReadingViewModel();
        private ReadingPrepViewModel _readingPrepViewModel;
        private AddEditDeviceViewModel _addEditViewModel;

        private IDevicesRepository _repo = new DevicesRepository();

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            _deviceListViewModel = ContainerHelper.Container.Resolve<DeviceListViewModel>();
            _addEditViewModel = ContainerHelper.Container.Resolve<AddEditDeviceViewModel>();
            _readingPrepViewModel = ContainerHelper.Container.Resolve<ReadingPrepViewModel>();
            //_deviceListViewModel.PlaceReadingRequested += NavToReading;
            _deviceListViewModel.AddDeviceRequested += NavToAddDevice;
            _deviceListViewModel.EditDeviceRequested += NavToEditDevice;
            _addEditViewModel.Done += NavToDeviceList;
        }

        private BindableBase _CurrentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "readingPrep":
                    CurrentViewModel = _readingPrepViewModel;
                    break;
                case "devices":
                default:
                    CurrentViewModel = _deviceListViewModel;
                    break;
            }
        }

        private void NavToReading()
        {
            //_readingViewModel.DeviceId = deviceId;
            CurrentViewModel = _readingPrepViewModel;
        }

        private void NavToAddDevice(Device device)
        {
            _addEditViewModel.EditMode = false;
            _addEditViewModel.SetDevice(device);
            CurrentViewModel = _addEditViewModel;
        }

        private void NavToEditDevice(Device device)
        {
            _addEditViewModel.EditMode = true;
            _addEditViewModel.SetDevice(device);
            CurrentViewModel = _addEditViewModel;
        }
        void NavToDeviceList()
        {
            CurrentViewModel = _deviceListViewModel;
        }

    }
}
