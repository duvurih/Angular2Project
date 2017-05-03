using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Hk.Services.AuthService.Controllers
{
    [RoutePrefix("api/testdata")]
    public class TestDataController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now serever time is " + DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet]
        [Route("authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",",roles.ToList()));
        }



    }
}
