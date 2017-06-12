using Hk.Utilities.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MultiProjectSample.Api
{
    [Authorize]
    [RoutePrefix("GoogleMapApiWeb")]
    public class GoogleMapApiController : BaseApiController
    {
        private IServiceManager _iServiceApiManager;

        public GoogleMapApiController(ISerializer serializer, IServiceManager iServiceApiManager) : base(serializer)
        {
            _iServiceApiManager = iServiceApiManager;
        }

        [HttpPost]
        [Route("GetGoogleMapLocation")]
        public async Task<HttpResponseMessage> GetGoogleMapLocation([FromBody] string address)
        {
            HttpResponseMessage response = null;
            await Task.Run(() =>
            {
                Dictionary<string, string> apiParams = new Dictionary<string, string>();
                apiParams.Add("address", address);

                string addressResult = _iServiceApiManager.GetAsync<string>("googlemapsapi", "GetGoogleMapLocation", apiParams);
                response = OkResponse(addressResult);
            });
            return response;
        }
    }
}
