using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hk.Utilities.Interfaces
{
    public interface ISerializer
    {
        #region Members

        /// <summary>
        /// Retrun serialized string from JSON Object
        /// </summary>
        /// <param name="data">Object to serialize</param>
        /// <param name="expand">Add Type information and Null values</param>
        string SerializeObject(object data, bool expand = false);

        /// <summary>
        /// Return object from JSON string
        /// </summary>
        /// <typeparam name="T">Object to deserialize</typeparam>
        /// <param name="jsonString">JSON string</param>
        /// <param name="expand">Use Type information and Null values</param>
        T DeserializeObject<T>(string jsonString, bool expand = false);

        #endregion
    }
}
