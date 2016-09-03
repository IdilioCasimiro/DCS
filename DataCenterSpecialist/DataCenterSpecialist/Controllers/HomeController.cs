using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DataCenterSpecialist.Controllers
{
    public class HomeController : Controller
    {
        //You can set the VaryByParam property to the following values:

        //* = Create a different cached version whenever a form or query string parameter varies.
        //none = Never create different cached versions
        //Semicolon list of parameters = Create different cached versions whenever any of the form or query string parameters in the list varies

        //[OutputCache(Duration = 120, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        [OutputCache(CacheProfile = "ChacheProfile")]
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