using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using log4net.Config;
using SQL_Web_Api.Services;
using Swashbuckle.Application;
using Unity;
using Unity.Lifetime;


namespace SQL_Web_Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/log4net.config")));


            var container = new UnityContainer();
            container.RegisterType<ILoggerService, LoggerService>();
            container.RegisterType<IDatabaseService, SqlServerDatabaseService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
