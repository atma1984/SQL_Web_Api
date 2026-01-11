using System.Web.Http;
using SQL_Web_Api.Services;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace SQL_Web_Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<ILoggerService, LoggerService>();
            container.RegisterType<IDatabaseService, SqlServerDatabaseService>(new ContainerControlledLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}