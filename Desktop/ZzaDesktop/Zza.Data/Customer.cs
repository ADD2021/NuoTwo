using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class Customer : INotifyPropertyChanged
    {
        public Customer()
        {
            Readings = new List<Order>();
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
   
        public List<Order> Readings { get; set; }

    }
}
