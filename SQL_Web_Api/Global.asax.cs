
using System.Web.Http;
using log4net.Config;

namespace SQL_Web_Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/log4net.config")));

            UnityConfig.RegisterComponents();

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
