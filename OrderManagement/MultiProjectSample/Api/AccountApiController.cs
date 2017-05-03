using MultiProjectSample.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [RoutePrefix("api/account")]
    public class AccountApiController : ApiController
    {
        [HttpGet]
        [Route(Name ="GetUserInfo")]
        [CachingFilter(5)]
        public int GetUserInfo()
        {
            return 1;
        }

    }
}
