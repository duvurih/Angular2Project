using System.IO;
using System.Web;

namespace Hk.TestCoverage.TestInitialization
{
    public class TestInitializationSettings
    {
        public static void HttpInitialization()
        {
            var httpRequest = new HttpRequest("", "http://localhost:55031/", "");
            var httpResponse = new HttpResponse(new StringWriter());

            var httpContext = new HttpContext(httpRequest, httpResponse);
            HttpContext.Current = httpContext;
        }
    }
}
