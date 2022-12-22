using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EFDBFirstApproachExample1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilter(GlobalFilters.Filters);
        }

        protected void Application_Error()
        {
            Exception exec = Server.GetLastError();
            string s = "Message :" + exec.Message + ",Type :" + exec.GetType().ToString() + ",Source :" + exec.Source;
            StreamWriter sw = File.AppendText(HttpContext.Current.Request.PhysicalApplicationPath + "//ErrorLog.txt");
            sw.WriteLine(s);
            sw.Close();
            Response.Redirect("Error.Html");
        }
    }
}
