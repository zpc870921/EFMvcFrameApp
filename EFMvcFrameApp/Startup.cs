using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using Unity.Mvc5;
using System.Web.Http;


[assembly: OwinStartup(typeof(EFMvcFrameApp.Startup))]

namespace EFMvcFrameApp
{
    #region 自定义的控制反转容器
    //public class MyDependencyReolver : IDependencyResolver
    //{
    //    IUnityContainer container;
    //    public MyDependencyReolver(IUnityContainer container)
    //    {
    //        this.container = container;
    //    }
    //    public object GetService(Type serviceType)
    //    {
    //        try 
    //        {
    //            return container.Resolve(serviceType);
    //        }
    //        catch {
    //            return null;
    //        }
    //    }

    //    public IEnumerable<object> GetServices(Type serviceType)
    //    {
    //        try
    //        {
    //            return container.ResolveAll(serviceType);
    //        }
    //        catch {
    //            return new List<object>();
    //        }
    //    }
    //}
    #endregion

    public class Startup
    {

        public static void Configuration()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            IUnityContainer container = new UnityContainer();
            section.Configure(container);
            //控制反转
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
