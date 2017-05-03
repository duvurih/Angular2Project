using Hk.Utilities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hk.Utilities.Utilities
{
    public class JSONSerializer : ISerializer
    {
        #region Members

        private readonly JsonSerializerSettings settingsDefault;

        private readonly JsonSerializerSettings settingsExpanded;

        #endregion

        #region Constructors

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

        #endregion
    }
}
