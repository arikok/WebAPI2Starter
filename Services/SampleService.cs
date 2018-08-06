using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WepAPI2Starter.Helpers;

namespace WepAPI2Starter.Services
{
    public class SampleService : ISampleService
    {
        public string getString()
        {
            string dpData = string.Empty; 
            string challange = string.Empty; 
            string logMessage = string.Empty;

            int sonuc = VascoHelper.ManagedGetChallange(ref dpData, out challange, out logMessage);

            return "sampleString";
        }
    }
}