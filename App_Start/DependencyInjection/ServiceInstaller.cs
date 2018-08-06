using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using WepAPI2Starter.Services;


namespace WepAPI2Starter.App_Start.DependencyInjection
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                            .BasedOn<IHttpController>()
                            .LifestylePerWebRequest());

            container.Register(
                Component.For<ISampleService>().ImplementedBy<SampleService>());
            
        }
    }
}