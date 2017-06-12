using Hk.Utilities.Interfaces;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hk.Services.Application1.Api
{
    [RoutePrefix("api/googlemapsapi")]
    public class GoogleMapsApiController : ApiController
    {
        private IServiceManager _iServiceApiManager;

        private string GetGoogleApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["GoogleApiURL"].ToString();
            }
        }

        private string GetGoogleApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["GoogleApiKey"].ToString();
            }
        }

        public GoogleMapsApiController(IServiceManager iServiceApiManager)
        {
            _iServiceApiManager = iServiceApiManager;
        }

        [Route("GetGoogleMapLocation/{address}")]
        [HttpGet]
        public async Task<string> GetGoogleMapLocation(string address)
        {
            string addressResult = null;
            await Task.Run(async () =>
            {
                addressResult = await _iServiceApiManager.GetExternalApiAsync<string>(GetGoogleApiUrl + "address=" + address + "&key=" + GetGoogleApiKey, null);
                return addressResult;
            });
            return addressResult;
        }
    }
}
