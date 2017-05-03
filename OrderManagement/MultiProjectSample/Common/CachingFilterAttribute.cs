using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace MultiProjectSample.Common
{
    public class CachingFilterAttribute: ActionFilterAttribute
    {
        public int MaxAge { get; set; }

        public CachingFilterAttribute(int maxAge)
        {
            MaxAge = maxAge;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode statusCode = actionExecutedContext.Response.StatusCode;

            //only apply to "successfull" responses
            if(statusCode==HttpStatusCode.OK || statusCode == HttpStatusCode.NotModified)
            {
                var response = actionExecutedContext.Response;
                var cacheControl = new CacheControlHeaderValue();
                cacheControl.MaxAge = TimeSpan.FromSeconds(MaxAge);
                response.Headers.CacheControl = cacheControl;
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}