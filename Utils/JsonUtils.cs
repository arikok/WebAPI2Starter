using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepAPI2Starter.Utils
{
    public class JsonUtils
    {
        public static string SerializeObject(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}