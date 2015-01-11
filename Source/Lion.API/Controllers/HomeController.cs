using Lion.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lion.API.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Test Method
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            IRepositoryContainer repocon = new RepositoryContainer();

            List<Lion.Domain.Models.AddressType> addressTypes = repocon.AddressTypeRepository.GetAll().ToList();

            return View(addressTypes);
        }
    }
}
