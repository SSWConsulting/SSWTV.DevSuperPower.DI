using System.Collections.Generic;
using System.Linq;
using AdamS.StoreTemp.Models;

namespace AdamS.OnlineStore.Models
{
    public interface ICustomerRepository
    {
        List<Customer> Get();
        Customer Get(int id);
        Customer Add(Customer customer);
        Customer Delete(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>
            {
                new Customer {Id = 1, FirstName = "Adam", LastName = "Apple"},
                new Customer {Id = 2, FirstName = "Brad", LastName = "Banana"},
                new Customer {Id = 3, FirstName = "Craig", LastName = "Canary"}
            };
        }

        public List<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(int id)
        {
            return _customers.Single(cust => cust.Id == id);
        }

        public Customer Add(Customer customer)
        {
            _customers.Add(customer);
            //todo: add Id field
            return customer;
        }

        public Customer Delete(int id)
        {
            Customer itemToRemove = _customers.SingleOrDefault(c => c.Id == id);

            if (itemToRemove != null)
            {
                _customers.Remove(itemToRemove);
            }
            return itemToRemove;
        }
    }
}
