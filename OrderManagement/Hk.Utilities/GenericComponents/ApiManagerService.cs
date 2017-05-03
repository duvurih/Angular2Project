using Hk.Utilities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hk.Utilities.GenericComponents
{
    public class ApiManagerService : IApiManager
    {
        ISerializer _iSerializer;

        private string GetInternalWebServiceUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["WebServiceURL"].ToString();
            }
        }

        public ApiManagerService(ISerializer iSerializer)
        {
            _iSerializer = iSerializer;
        }

        public async Task<T> GetAsync<T>(string controller, string action = null, Dictionary<string, string> data = null)
        {
            string apiParameters = controller + (!string.IsNullOrEmpty(action) ? "/" + action : "");
            if (data != null)
            {
                foreach (KeyValuePair<string, string> keyValuePair in data)
                {
                    apiParameters = apiParameters + "/" + keyValuePair.Value;
                }
            }

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                string serviceUrl = GetInternalWebServiceUrl + apiParameters;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                    );

                //HttpResponseMessage response = await httpClient.GetAsync(serviceUrl).Result;
                HttpResponseMessage response = await httpClient.GetAsync(serviceUrl);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.ReasonPhrase, new Exception(response.Content.ReadAsStringAsync().Result));
                }
                //return Deserialize<T>(response);
                return _iSerializer.DeserializeObject<T>(response.ToString(), false);
            }

        }

        public async Task<T> PostAsync<T>(string controller, string action, object data)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                string serviceUrl = GetInternalWebServiceUrl + controller + "/" + action;
                httpClient.DefaultRequestHeaders.Accept.Clear();

                //HttpResponseMessage response = httpClient.PostAsJsonAsync(serviceUrl, data).Result;
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(serviceUrl, data);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.ReasonPhrase, new Exception(response.Content.ReadAsStringAsync().Result));
                }
                //return Deserialize<T>(response);
                return _iSerializer.DeserializeObject<T>(response.ToString(), false);
            }
        }

        private T Deserialize<T>(HttpResponseMessage response)
        {
            var deserialized = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            return deserialized;
        }
    }
}
