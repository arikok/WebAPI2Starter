using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepAPI2Starter.Common
{
    public class NetbankingResponseObject
    {
        public bool hasError { get; set; }
        public string message { get; set; }
        public Object dataObject { get; set; }
    }
}