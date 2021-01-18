using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ZzaDesktop.Customers
{
    public class SimpleEditableCustomer : ValidatableBindableBase
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _address;
        [Required]
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

       


    }

}
