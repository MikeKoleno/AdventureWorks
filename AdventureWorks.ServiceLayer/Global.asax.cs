using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AdventureWorks.ServiceLayer
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new ServiceRoute("employees",
                       new WebServiceHostFactory(), typeof(EmployeeService)));
            routes.Add(new ServiceRoute("shifts",
                       new WebServiceHostFactory(), typeof(ShiftService)));
        }
    }
}