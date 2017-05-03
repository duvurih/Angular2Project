using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    public class BaseApiController : ApiController
    {
        ISerializer _serializer;

        public BaseApiController(ISerializer serializer)
        {
            _serializer = serializer;
        }

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

    }
}
