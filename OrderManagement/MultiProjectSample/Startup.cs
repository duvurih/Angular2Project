using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using MultiProjectSample.Common;
using Owin;

namespace MultiProjectSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            //ResponseType is "id_token" based on "ImplicitFlow" defined in "Clients"
            //IF ResponseType is "code id_token" than Flow in Clients is "HybridFlow"
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:44386/identity",
                ClientId = "mvc",
                Scope = "openid profile roles",
                RedirectUri = "http://localhost:50381/",
                ResponseType = "id_token",
                SignInAsAuthenticationType = "Cookies",
                UseTokenLifetime = false
                //Notifications = new OpenIdConnectAuthenticationNotifications
                //{
                //    SecurityTokenValidated = n =>
                //    {
                //        var id = n.AuthenticationTicket.Identity;

                //        // we want to keep first name, last name, subject and roles
                //        var givenName = id.FindFirst(Constants.ClaimTypes.GivenName);
                //        var familyName = id.FindFirst(Constants.ClaimTypes.FamilyName);
                //        var sub = id.FindFirst(Constants.ClaimTypes.Subject);
                //        var roles = id.FindAll(Constants.ClaimTypes.Role);

                //        // create new identity and set name and role claim type
                //        var nid = new ClaimsIdentity(
                //            id.AuthenticationType,
                //            Constants.ClaimTypes.GivenName,
                //            Constants.ClaimTypes.Role);

                //        nid.AddClaim(givenName);
                //        nid.AddClaim(familyName);
                //        nid.AddClaim(sub);
                //        nid.AddClaims(roles);

                //        // add some other app specific claim
                //        nid.AddClaim(new Claim("app_specific", "some data"));

                //        n.AuthenticationTicket = new AuthenticationTicket(
                //            nid,
                //            n.AuthenticationTicket.Properties);

                //        return Task.FromResult(0);
                //    }
                //}
            });

            app.UseResourceAuthorization(new AuthorizationManager());

        }
    }
}