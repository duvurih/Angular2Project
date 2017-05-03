using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace Hk.Services.AuthService.Common
{
    public class AppAuthorizationServiceProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //return base.ValidateClientAuthentication(context);
            context.Validated(); //validate client
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //return base.GrantResourceOwnerCredentials(context);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hari"));
                context.Validated(identity);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Krishna"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }

        //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

        //    try
        //    {
        //        //retrieve your user from database. ex:
        //        var user = await userService.Authenticate(context.UserName, context.Password);

        //        var identity = new ClaimsIdentity(context.Options.AuthenticationType);

        //        identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
        //        identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

        //        //roles example
        //        var rolesTechnicalNamesUser = new List<string>();

        //        if (user.Roles != null)
        //        {
        //            rolesTechnicalNamesUser = user.Roles.Select(x => x.TechnicalName).ToList();

        //            foreach (var role in user.Roles)
        //                identity.AddClaim(new Claim(ClaimTypes.Role, role.TechnicalName));
        //        }

        //        var principal = new GenericPrincipal(identity, rolesTechnicalNamesUser.ToArray());

        //        Thread.CurrentPrincipal = principal;

        //        context.Validated(identity);
        //    }
        //    catch (Exception ex)
        //    {
        //        context.SetError("invalid_grant", "message");
        //    }
        //}

    }
}