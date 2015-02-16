using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AdamS.Domain;
using AdamS.RepositoryInterfaces;

namespace AdamS.SQLData
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>
            {
                new Customer{Id=1,FirstName = "Adam", LastName = "Apple"}, 
                new Customer{Id=2,FirstName = "Brad", LastName = "Banana"},
                new Customer{Id=3,FirstName = "Craig", LastName = "Canary"}
            };
        public Customer Get(int id)
        {
            return _customers.Single(cust => cust.Id == id);
        }

        public List<Customer> Get()
        {
            return _customers;
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
