using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.Devices
{
    class DeviceListViewModel : BindableBase
    {
        private IDevicesRepository _repo;

        public DeviceListViewModel(IDevicesRepository repo)
        {
            _repo = repo;
            PlaceReadingCommand = new RelayCommand<Device>(OnPlaceReading);
            AddDeviceCommand = new RelayCommand(OnAddDevice);
            EditDeviceCommand = new RelayCommand<Device>(OnEditDevice);
            ClearSearchCommand = new RelayCommand(OnClearSearch);
            DeleteDeviceCommand = new RelayCommand<Device>(DeleteDevice);


        }

        private ObservableCollection<Device> _devices;
        public ObservableCollection<Device> Devices
        {
            get { return _devices; }
            set { SetProperty(ref _devices, value); }
        }


        private List<Device> _allDevices;

        public async void LoadDevices()
        {
            _allDevices = await _repo.GetDevicesAsync();
            Devices = new ObservableCollection<Device>(_allDevices);
        }
        public async void DeleteDevice(Device cust)
        {
            await _repo.DeleteDeviceAsync(cust.Id);
            _allDevices = await _repo.GetDevicesAsync();
            Devices = new ObservableCollection<Device>(_allDevices);
        }



        private string _SearchInput;

        public string SearchInput
        {
            get { return _SearchInput; }
            set
            {
                SetProperty(ref _SearchInput, value);
                FilterDevices(_SearchInput);
            }
        }

        private void FilterDevices(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Devices = new ObservableCollection<Device>(_allDevices);
                return;
            }
            else
            {
                Devices = new ObservableCollection<Device>(
                    _allDevices.Where(c => c.Address.ToLower().Contains(searchInput.ToLower())));
            }
        }

        public RelayCommand<Device> PlaceReadingCommand { get; private set; }
        public RelayCommand AddDeviceCommand { get; private set; }
        public RelayCommand<Device> EditDeviceCommand { get; private set; }

        public RelayCommand<Device> DeleteDeviceCommand { get;  set; }
        public RelayCommand ClearSearchCommand { get; private set; }


        public event Action<Guid> PlaceReadingRequested = delegate { };
        public event Action<Device> AddDeviceRequested = delegate { };
        public event Action<Device> EditDeviceRequested = delegate { };
     

        void OnPlaceReading(Device devic)
        {
            PlaceReadingRequested(devic.Id);
        }

        void OnAddDevice()
        {
            AddDeviceRequested(new Device { Id = Guid.NewGuid() });
        }

        void OnEditDevice(Device cust)
        {
            EditDeviceRequested(cust);
        }

       
        private void OnClearSearch()
        {
            SearchInput = null;
        }

    }
}
