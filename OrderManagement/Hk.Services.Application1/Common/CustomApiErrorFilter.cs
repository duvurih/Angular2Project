using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Hk.Services.Application1.Common
{
    public class CustomApiErrorFilter : ExceptionFilterAttribute
    {
        #region Members


        #endregion

        #region Constructors

        public CustomApiErrorFilter()
        {
        }

        #endregion

        #region Event handlers

        public override void OnException(HttpActionExecutedContext filterContext)
        {
            // Exact message for business exceptions which have been thrown deliberately need to be shown
            // However for other types of unhandled exceptions a generic message should be shown
            var exceptionMessage = filterContext.Exception.Message;

            // Constructing a proper message
            var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(exceptionMessage),
                ReasonPhrase = exceptionMessage.Replace("\n", " ").Replace("\r", "")
            };

        }

        #endregion

    }
}
