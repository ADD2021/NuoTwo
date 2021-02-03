using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class Device : INotifyPropertyChanged
    {
        public Device()
        {
            Readings = new List<Reading>();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [Key]
        public Guid Id { get; set; }
        string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Address"));
            }
        }
   
        public List<Reading> Readings { get; set; }

    }
}
