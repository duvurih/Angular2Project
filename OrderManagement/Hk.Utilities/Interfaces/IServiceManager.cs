using System.Collections.Generic;

namespace Hk.Utilities.Interfaces
{
    public interface IServiceManager
    {
        T GetAsync<T>(string controller, string action = null, Dictionary<string, string> data = null);

        T PostAsync<T>(string controller, string action, object data);
    }
}
