using System.Collections.Generic;
using System.Linq;
using AdamS.Domain;
using AdamS.RepositoryInterfaces;

namespace AdamS.SQLData
{
    public class OrderRepository : IOrdersRepository
    {

        private List<Order> _orders = new List<Order>
        {
            new Order{Id=1,CustomerId = 1, OrderTotal = 12.45M}, 
            new Order{Id=2,CustomerId = 1, OrderTotal = 23.00M}, 
            new Order{Id=3,CustomerId = 2, OrderTotal = 54.50M}, 
        };

        
        public List<Order> Get(int customerId)
        {
            return _orders.Where(c => c.CustomerId == customerId).ToList();
        }
    }
}