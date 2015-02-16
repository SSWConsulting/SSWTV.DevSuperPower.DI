using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdamS.StoreTemp.Models;

namespace AdamS.StoreTemp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ICustomerRepository _customerRepository;
        
        public HomeController(ICustomerRepository customerRepository)
        {
            
            _customerRepository = customerRepository;
        }
        
        public string TestCustomerRepository(int id)
        {
            var customer = _customerRepository.Get(id);

            return string.Format("{0} {1}", customer.FirstName, customer.LastName);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}