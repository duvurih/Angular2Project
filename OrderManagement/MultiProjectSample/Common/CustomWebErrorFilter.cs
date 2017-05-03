using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiProjectSample.Common
{
    public class CustomWebErrorFilter : HandleErrorAttribute
    {
        #region Event handlers

        public override void OnException(ExceptionContext filterContext)
        {
            //No further processing when the exception is handled
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            // Exact message for business exceptions which have been thrown deliberately need to be shown
            // However for other types of unhandled exceptions a generic message should be shown            
            var exceptionMessage = filterContext.Exception.Message;
            var requestUri = filterContext.RequestContext.HttpContext.Request.Url.ToString();

            base.OnException(filterContext);
        }

        #endregion
    }
}