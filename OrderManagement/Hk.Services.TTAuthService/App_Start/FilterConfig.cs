using System.Web;
using System.Web.Mvc;

namespace Hk.Services.TTAuthService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
