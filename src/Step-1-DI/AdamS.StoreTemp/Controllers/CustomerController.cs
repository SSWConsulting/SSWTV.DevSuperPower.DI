using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdamS.StoreTemp.Models;

namespace AdamS.StoreTemp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationProvider _notificationProvider;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger _logger;

        public CustomerController(ICustomerRepository customerRepository, INotificationProvider notificationProvider, IOrdersRepository ordersRepository, ILogger logger)
        {
            _customerRepository = customerRepository;
            _notificationProvider = notificationProvider;
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var allCustomers = _customerRepository.Get();

            return View(allCustomers);
        }

        public ActionResult Delete(int id)
        {
            
            try
            {
                var customerHasOrders = _ordersRepository.Get(id).Count > 0;

                if (customerHasOrders)
                {
                    return Content( "Unable to delete customer due to existing invoices.");
                }
                
                _customerRepository.Delete(id);

                _notificationProvider.Send("admin@mycompany.com", "Customer Deleted", string.Format("Customer Deleted : ", id));

                _logger.Info("Deleted Customer with Id: {0}",id);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error Deleting Customer Id: {0}", id);

                return Content( "Unable to delete customer");
            }

        }

    }
}