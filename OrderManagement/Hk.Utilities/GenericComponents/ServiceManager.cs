using Hk.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hk.Utilities.GenericComponents
{
    public class ServiceManager : IServiceManager
    {
        #region "Members"
        ISerializer _iSerializer;

        private string GetInternalWebServiceUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["WebServiceURL"].ToString();
            }
        }

        #endregion

        #region "Constructor"
        public ServiceManager(ISerializer iSerializer)
        {
            _iSerializer = iSerializer;
        }
        #endregion

        #region "Methods"
        public T GetAsync<T>(string controller, string action = null, Dictionary<string, string> data = null)
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

                HttpResponseMessage response = httpClient.GetAsync(serviceUrl).Result;
                //HttpResponseMessage response = await httpClient.GetAsync(serviceUrl);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.ReasonPhrase, new Exception(response.Content.ReadAsStringAsync().Result));
                }
                return _iSerializer.DeserializeHttpResponse<T>(response);
                //return _iSerializer.DeserializeObject<T>(response.ToString(), false);
            }

        }

        public T PostAsync<T>(string controller, string action, object data)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                string serviceUrl = GetInternalWebServiceUrl + controller + "/" + action;
                httpClient.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = httpClient.PostAsJsonAsync(serviceUrl, data).Result;
                //HttpResponseMessage response = await httpClient.PostAsJsonAsync(serviceUrl, data);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.ReasonPhrase, new Exception(response.Content.ReadAsStringAsync().Result));
                }
                return _iSerializer.DeserializeHttpResponse<T>(response);
                //return _iSerializer.DeserializeObject<T>(response.ToString(), false);
            }
        }
        #endregion

        #region "External Service Calls Methods"
        public async Task<T> GetExternalApiAsync<T>(string externalApi, Dictionary<string, string> data = null)
        {
            string apiParameters = externalApi;
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
                string serviceUrl = apiParameters;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                    );

                HttpResponseMessage response = httpClient.GetAsync(serviceUrl).Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.ReasonPhrase, new Exception(response.Content.ReadAsStringAsync().Result));
                }
                return _iSerializer.DeserializeHttpResponse<T>(response);
                //return _iSerializer.DeserializeObject<T>(response.ToString(), false);
            }

        }

        public async Task<T> PostExternalApiAsync<T>(string externalApi, object data)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                string serviceUrl = externalApi;
                httpClient.DefaultRequestHeaders.Accept.Clear();

                HttpResponseMessage response = httpClient.PostAsJsonAsync(serviceUrl, data).Result;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.ReasonPhrase, new Exception(response.Content.ReadAsStringAsync().Result));
                }
                return _iSerializer.DeserializeHttpResponse<T>(response);
                //return _iSerializer.DeserializeObject<T>(response.ToString(), false);
            }
        }
        #endregion
    }
}
