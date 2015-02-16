using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdamS.Domain;

namespace AdamS.RepositoryInterfaces
{

    public interface IOrdersRepository
    {
        List<Order> Get(int customerId);
    }

    public interface ICustomerRepository
    {
        Customer Get(int id);
        List<Customer> Get();
        
        Customer Add(Customer customer);
        Customer Delete(int id);
    }

}
