using DataCenterSpecialist.Controllers.ErrorManager;
using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DataCenterSpecialist
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //public void Application_Error(Object sender, EventArgs args)
        //{
        //    if (Server != null)
        //    {
        //        //Fazer referência ao contexto
        //        HttpContext contexto = ((MvcApplication)sender).Context;
        //        //Fazer log da exception
        //        Exception ex = Server.GetLastError().GetBaseException();
        //        //Logger.Error(ex); -------- Tratar disso
        //        //Apaga o último erro do servidor, portanto os erros personalizados não são disparados
        //        Server.ClearError();
        //        //Redirecionar o usuário para o controller que vai tratar do erro
        //        IController errorController = new ErrorManagerController();
        //        //Adicionar a rota para o controller correspondente
        //        RouteData rota = new RouteData();
        //        rota.Values["controller"] = "ErrorManagerController";
        //        rota.Values["action"] = "ErroDesconhecido";

        //        errorController.Execute(new RequestContext(new HttpContextWrapper(contexto), rota));
        //    }
        //}
    }
}
