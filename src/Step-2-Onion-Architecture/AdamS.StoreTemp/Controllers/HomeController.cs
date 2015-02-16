using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdamS.RepositoryInterfaces;
using AdamS.StoreTemp.Models;

namespace AdamS.StoreTemp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStateProvider _sessionProvider;
        private readonly ICustomerRepository _customerRepository;
        
        public HomeController(IStateProvider sessionProvider,ICustomerRepository customerRepository)
        {
            _sessionProvider = sessionProvider;
            _customerRepository = customerRepository;
        }

        public string TestStateProvider(string id)
        {
            return _sessionProvider.Get(id);
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