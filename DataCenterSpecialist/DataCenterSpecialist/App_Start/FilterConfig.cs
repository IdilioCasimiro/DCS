using System;
using System.Web;
using System.Web.Mvc;

namespace DataCenterSpecialist
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(System.Data.SqlClient.SqlException),
                View = "~/ErrorManager/ErroServidor.cshtml"
            });
            //filters.Add(new AuthorizeAttribute());
        }
    }
}
