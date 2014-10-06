using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFMvcFrame.Controllers.Api;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Http;
using EFMvcFrame.Interface;
using System.Web;
using EFMvcFrame.Model.Entites;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        IUnityContainer container;
        [TestInitialize]
        public void TestInit()
        {
            var config = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            container = new UnityContainer();
            config.Configure(container);


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        [TestMethod]
        public void TestMethod1()
        {
            IPerson personSvc = container.Resolve<IPerson>();
            PersonController pc = new PersonController(personSvc);
            var personmodel = new Person
            {
                Id = 0,
                Age = 22,
                Address = "aaa",
                Mobile = "15313150410",
                Name = "zoupch",
                Sex = true,
                 CreateTime=DateTime.Now
            };
            var result= pc.AddPerson(personmodel);
            Assert.IsTrue(result>0);
        }
    }
}
