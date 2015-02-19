using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AdamS.OnlineStore.Models;

namespace AdamS.OnlineStore.Controllers
{
    public class CustomerController : Controller
    {
        private INotificationProvider _notificationProvider ;

        public CustomerController(INotificationProvider notification)
        {
            _notificationProvider = notification;
        }

        public ActionResult Index()
        {
            var customerDb = new CustomerRepository();

            var allCustomers = customerDb.Get();

            
            return View(allCustomers);
        }

        public ActionResult Delete(int id)
        {
            var logger = new FileSystemLogger();
            var notifcation = new EmailSender();

            try
            {
                var ordersData = new OrderRepository();

                var customerHasOrders = ordersData.Get(id).Count > 0;

                if (customerHasOrders)
                {
                    return Content( "Unable to delete customer due to existing invoices.");
                }

                var customerDb = new CustomerRepository();

                customerDb.Delete(id);

                var statusMessage = string.Format("Customer Deleted : {0}", id);

                notifcation.Send("admin@mycompany.com", "Customer Deleted", statusMessage);

                logger.Info(statusMessage);

                return Content(statusMessage);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error Deleting Customer Id: {0}", id);

                return Content( "Unable to delete customer");
            }

        }

    }
}