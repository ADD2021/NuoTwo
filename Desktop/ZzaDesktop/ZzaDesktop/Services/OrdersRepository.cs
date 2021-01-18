using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Zza.Data;
namespace ZzaDesktop.Services
{
    public class OrdersRepository : IOrdersRepository
    {
        ZzaDbContext _context = new ZzaDbContext();

        public async Task<List<Order>> GetOrdersForCustomersAsync(Guid customerId)
        {
            return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            if (!_context.Orders.Local.Any(o => o.Id == order.Id))
            {
                _context.Orders.Attach(order);
            }
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {

                    _context.Orders.Remove(order);
                }
                await _context.SaveChangesAsync();
                scope.Complete();
            }
        }



    }
}
