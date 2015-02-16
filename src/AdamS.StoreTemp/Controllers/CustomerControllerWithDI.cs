using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdamS.Domain;
using AdamS.Domain.Interfaces;
using AdamS.RepositoryInterfaces;
using AdamS.SQLData;

namespace AdamS.StoreTemp.Controllers
{
    public class CustomerDIController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger _logger;
        private readonly INotificationProvider _notificationProvider;

        public CustomerDIController(ICustomerRepository customerRepository, IOrdersRepository ordersRepository, ILogger logger, INotificationProvider notificationProvider)
        {
            _customerRepository = customerRepository;
            _ordersRepository = ordersRepository;
            _logger = logger;
            _notificationProvider = notificationProvider;
        }

        public ActionResult Index()
        {
            var allCustomers = _customerRepository.Get();

            return View(allCustomers);
        }

        public string Delete(int id)
        {
            
            try
            {
                var customerHasOrders = _ordersRepository.Get(id).Count > 0;

                if (customerHasOrders)
                {
                    return "Unable to delete customer due to existing invoices.";
                }
                
                _customerRepository.Delete(id);

                _notificationProvider.Send("admin@mycompany.com", "Customer Deleted", string.Format("Customer Deleted : ", id));

                _logger.Info("Deleted Customer with Id: {0}",id);

                return "Customer deleted";

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error Deleting Customer Id: {0}", id);

                return "Unable to delete customer";
            }

        }

    }
}