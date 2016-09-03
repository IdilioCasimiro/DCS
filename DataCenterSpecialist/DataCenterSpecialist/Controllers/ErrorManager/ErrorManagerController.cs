using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCenterSpecialist.Controllers.ErrorManager
{
    public class ErrorManagerController : Controller
    {
        
        public ActionResult ErroDesconhecido()
        {
            return View();
        }

        public ActionResult ErroServidor()
        {
            return View();
        }

        public ActionResult Erro404()
        {
            return View();
        }
    }
}