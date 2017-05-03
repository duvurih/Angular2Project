using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace Hk.Services.TTAuthService.Models
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
            new Client
            {
                Enabled = true,
                ClientName = "MVC Client",
                ClientId = "mvc",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "http://localhost:50381/"
                },

                AllowAccessToAllScopes = true
            }
        };
        }
    }
}