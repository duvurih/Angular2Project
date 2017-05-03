using Hk.Utilities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;

namespace Hk.Utilities.Utilities
{
    public class JSONSerializer : ISerializer
    {
        #region Members

        private readonly JsonSerializerSettings settingsDefault;

        private readonly JsonSerializerSettings settingsExpanded;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public JSONSerializer()
        {
            settingsDefault = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                TypeNameHandling = TypeNameHandling.None
            };

            settingsExpanded = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                TypeNameHandling = TypeNameHandling.Objects
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrun serialized string from JSON Object
        /// </summary>
        /// <param name="data">Object to serialize</param>
        /// <param name="expand">Add Type information and Null values</param>
        public string SerializeObject(object data, bool expand = false)
        {
            return JsonConvert.SerializeObject(data, expand ? settingsExpanded : settingsDefault);
        }

        /// <summary>
        /// Return object from JSON string
        /// </summary>
        /// <typeparam name="T">Object to deserialize</typeparam>
        /// <param name="jsonString">JSON string</param>
        /// <param name="expand">Use Type information and Null values</param>
        public T DeserializeObject<T>(string jsonString, bool expand = false)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, expand ? settingsExpanded : settingsDefault);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public T DeserializeHttpResponse<T>(HttpResponseMessage response)
        {
            var deserialized = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            return deserialized;
        }

        #endregion
    }
}
