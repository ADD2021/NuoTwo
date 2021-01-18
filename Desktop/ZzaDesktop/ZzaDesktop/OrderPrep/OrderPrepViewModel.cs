using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDesktop.Services;

namespace ZzaDesktop.OrderPrep
{
    class OrderPrepViewModel : BindableBase
    {
        private IOrdersRepository _repo;
        public OrderPrepViewModel(IOrdersRepository repo)
        {
            _repo = repo;
        }
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set { SetProperty(ref _orders, value); }
        }


        private List<Order> _allOrders;

        public async void LoadCustomers()
        {
            _allOrders = await _repo.GetAllOrdersAsync();
            Orders = new ObservableCollection<Order>(_allOrders);
        }
    }
}
