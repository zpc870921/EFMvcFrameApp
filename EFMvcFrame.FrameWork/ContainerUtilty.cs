using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EFMvcFrame.FrameWork
{
    public class ContainerUtilty
    {
        public static IUnityContainer container;
        public static IUnityContainer Container {
            get {
                if (container == null)
                {
                    container = new UnityContainer();
                    UnityConfigurationSection config = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                    config.Configure(container);
                }
                return container;
            }
        }
    
    }
}
