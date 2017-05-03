using Hk.Utilities.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    public class BaseApiController : ApiController
    {
        #region "Members"
        ISerializer _serializer;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Base Api Constructor
        /// </summary>
        /// <param name="serializer">Injecting ISerializer</param>
        public BaseApiController(ISerializer serializer)
        {
            _serializer = serializer;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Converting the Object to HttpResponseMessage
        /// </summary>
        /// <param name="contents">Object Content</param>
        /// <returns>Returns JSON Results</returns>
        protected HttpResponseMessage OkResponse(object contents)
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(
                    _serializer.SerializeObject(contents),
                    System.Text.Encoding.UTF8,
                    "application/json");
                return response;
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex);
            }
        }

        /// <summary>
        /// Converting Exception to Http Response Message
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>Returns Json Result</returns>
        protected HttpResponseMessage ErrorResponse(Exception ex)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(
                _serializer.SerializeObject(new
                {
                    Status = false,
                    Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message
                }),
                System.Text.Encoding.UTF8,
                "application/json");
            return response;
        }
        #endregion

    }
}
