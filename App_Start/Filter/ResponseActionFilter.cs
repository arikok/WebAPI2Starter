using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using WepAPI2Starter.Common;

namespace WepAPI2Starter.App_Start.Filter
{
    public class ResponseActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
                if (value.GetType() != typeof(NetbankingResponseObject))
                {
                    NetbankingResponseObject responseObject = new NetbankingResponseObject();
                    responseObject.dataObject = value;
                    responseObject.hasError = false;
                    objectContent.Value = responseObject;
                }

            }
        }
    }
}