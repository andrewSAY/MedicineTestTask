using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Net.Http;
using MedicineTestTask.DI;
using MedicineTestTask.Interfaces;
using DependencyResolver = MedicineTestTask.DI.DependencyResolver;

namespace MedicineTestTask
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            var depedendencyResolver = DependencyResolver.GetInstance();
            var logger = depedendencyResolver.Resolve<IAsyncRepository>();
            var requestLoggingHandler = depedendencyResolver.Resolve<DelegatingHandler>();
            GlobalConfiguration.Configuration.MessageHandlers.Add(requestLoggingHandler);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);            
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}