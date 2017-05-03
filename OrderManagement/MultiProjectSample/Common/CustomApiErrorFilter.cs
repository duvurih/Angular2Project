using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace MultiProjectSample.Common
{
    public class CustomApiErrorFilter : ExceptionFilterAttribute
    {
        #region Event handlers

        public override void OnException(HttpActionExecutedContext filterContext)
        {
            // Exact message for business exceptions which have been thrown deliberately need to be shown
            // However for other types of unhandled exceptions a generic message should be shown
            while (filterContext.Exception.InnerException != null)
            {
                filterContext.Exception = filterContext.Exception.InnerException;
            }

            var exceptionMessage = filterContext.Exception.Message;
            var requestUri = filterContext.Request.RequestUri.ToString();
        }

        #endregion
    }
}