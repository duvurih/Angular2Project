using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hk.Utilities.Interfaces
{
    public interface IApiManager
    {
        // T GetAsync<T>(string controller, string action = null, Dictionary<string, string> data = null);
        Task<T> GetAsync<T>(string controller, string action = null, Dictionary<string, string> data = null);

        Task<T> PostAsync<T>(string controller, string action, object data);
    }
}
