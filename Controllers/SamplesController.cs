using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WepAPI2Starter.Constants;
using WepAPI2Starter.Models;
using WepAPI2Starter.Services;

namespace WepAPI2Starter.Controllers
{
    // Sample usages and project standarts.
    
    // All controller must inherit from AbstractBaseApiController
    public class SamplesController : AbstractBaseApiController
    {

        // DI Dependency Injection in controllers could done with below code part
        // When you create a new service, you should add that service to ServiceInstaller.cs
        private readonly ISampleService sampleService;
        public SamplesController(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        // If you want to log something; you need to creat a instance of logger than you can use it in methods
        private static Logger logger = LogManager.GetCurrentClassLogger();


        // Use AllowAnonymous keyword for public Routes which doesnt require an authentication
        [Route(Routes.SampleService.Sample)]
            // All Route Urls in actions must be used from Routes.cs which placed at Common Project
        [HttpPost]
            // Using HTTP POST method is project standart. Dont use GET-PUT-DELETE Methods
        public SampleServiceModel sample(SampleServiceModel sampleServiceInput)
            // All methods must return a complex object. Dont return primitive types like int,string
            // All method input objects must be defined at Model folder
        {

            string outputkey = sampleService.getString();

            SampleServiceModel outputModel = new SampleServiceModel();

            outputModel.outputString = outputkey;

            //logging with log level 
            logger.Error("error");
            logger.Info("info");

            return outputModel;
        }

    }
}
