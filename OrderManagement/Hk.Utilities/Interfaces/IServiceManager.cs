using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hk.Utilities.Interfaces
{
    public interface IServiceManager
    {
        T GetAsync<T>(string controller, string action = null, Dictionary<string, string> data = null);

        T PostAsync<T>(string controller, string action, object data);

        Task<T> GetExternalApiAsync<T>(string externalApi, Dictionary<string, string> data = null);

        Task<T> PostExternalApiAsync<T>(string externalApi, object data);
    }
}
