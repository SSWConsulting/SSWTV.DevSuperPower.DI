using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdamS.Domain;
using AdamS.SQLData;

namespace AdamS.StoreTemp.Controllers
{
    public class CustomerController : Controller
    {
        
        public ActionResult Index()
        {
            var customerDb = new CustomerRepository();

            var allCustomers = customerDb.Get();

            return View(allCustomers);
        }

        public string Delete(int id)
        {
            var logger = new FileSystemLogger();
            var notifcation = new EmailSender.EmailSender();
            
            try
            {
                var ordersData = new OrderRepository();

                var customerHasOrders = ordersData.Get(id).Count > 0;

                if (customerHasOrders)
                {
                    return "Unable to delete customer due to existing invoices.";
                }
                
                var customerDb = new CustomerRepository();

                customerDb.Delete(id);

                notifcation.Send("admin@mycompany.com", "Customer Deleted", string.Format("Customer Deleted : ", id));

                logger.Info("Deleted Customer with Id: {0}",id);

                return "Customer deleted";

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error Deleting Customer Id: {0}", id);

                return "Unable to delete customer";
            }

        }

    }
}