using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace Hk.Services.TTAuthService.Models
{
    public static class Users
    {
        //public static IEnumerable<InMemoryUser> Get()
        //{
        //    return new[]
        //    {
        //        new InMemoryUser
        //        {
        //            Username = "bob",
        //            Password = "secret",
        //            Subject = "1",

        //            Claims = new[]
        //            {
        //                new Claim(Constants.ClaimTypes.GivenName, "Bob"),
        //                new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
        //                new Claim(Constants.ClaimTypes.Role, "Geek"),
        //                new Claim(Constants.ClaimTypes.Role, "Foo")
        //            }
        //        }
        //    };
        //}
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "bob",
                    Password = "secret",
                    Subject = "1",

                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(Constants.ClaimTypes.Role, "Geek"),
                        new Claim(Constants.ClaimTypes.Role, "Foo")
                    }
                }
            };
        }

    }
}