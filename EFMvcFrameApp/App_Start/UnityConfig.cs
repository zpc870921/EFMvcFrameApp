using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Web.Http;
using Unity.WebApi;

namespace EFMvcFrameApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            IUnityContainer container = new UnityContainer();
            section.Configure(container);
			//var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}