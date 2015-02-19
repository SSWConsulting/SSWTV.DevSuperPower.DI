using System.Collections.Generic;
using System.Linq;

namespace AdamS.OnlineStore.Models
{
    public class OrderRepository
    {
        private List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>{
                new Order{Id=1,CustomerId = 1, OrderTotal = 12.45M}, 
                new Order{Id=2,CustomerId = 1, OrderTotal = 23.00M}, 
                new Order{Id=3,CustomerId = 1, OrderTotal = 54.50M}, 
            };
        }

        public List<Order> Get(int customerId)
        {
            return _orders.Where(c => c.CustomerId == customerId).ToList();
        }
    }
}