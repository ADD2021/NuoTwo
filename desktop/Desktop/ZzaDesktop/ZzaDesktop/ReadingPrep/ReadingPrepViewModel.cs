using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.ReadingPrep
{
    class ReadingPrepViewModel : BindableBase
    {
        private IReadingsRepository _repo;
        public ReadingPrepViewModel(IReadingsRepository repo)
        {
            _repo = repo;
        }
        private ObservableCollection<Reading> _readings;
        public ObservableCollection<Reading> Readings
        {
            get { return _readings; }
            set { SetProperty(ref _readings, value); }
        }


        private List<Reading> _allReadings;

        public async void LoadReadings()
        {
            _allReadings = await _repo.GetAllReadingsAsync();
            Readings = new ObservableCollection<Reading>(_allReadings);
        }
    }
}
