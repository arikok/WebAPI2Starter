using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WepAPI2Starter.App_Start.Filter;
using WepAPI2Starter.App_Start.ExceptionHandling;
using WepAPI2Starter.App_Start.DependencyInjection;

[assembly: OwinStartup(typeof(WepAPI2Starter.App_Start.Startup))]

namespace WepAPI2Starter.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var httpConfig = new HttpConfiguration();

            httpConfig.MapHttpAttributeRoutes();

            httpConfig.Filters.Add(new ResponseActionFilter());
            
            httpConfig.Services.Replace(typeof(IExceptionHandler), new PassthroughExceptionHandler());

            CastleWindsorHelper.ConfigureWindsor(httpConfig);

            app.Use<OwinExceptionHandlerMiddleware>();

            app.UseWebApi(httpConfig);

        }
    }
}