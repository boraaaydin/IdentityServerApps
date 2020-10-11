using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

internal class Clients
{
    public static IEnumerable<Client> Get()
    {
        return new List<Client>
        {
            new Client
            {
                ClientId = "oauthClient",
                ClientName = "Example client application using client credentials",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                AllowedScopes = new List<string> {"api1.read"}
            },
            new Client
            {
                ClientId = "oidcClient",
                ClientName = "Example Client Application",
                ClientSecrets = new List<Secret> {new Secret("SuperSecretPassword".Sha256())}, // change me!
                
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = new List<string> {"https://localhost:6001/signin-oidc"},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "api1.read"
                },

                RequirePkce = true,
                AllowPlainTextPkce = false
            },
            // interactive ASP.NET Core MVC client
            new Client
            {
                ClientId = "mvc",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                // where to redirect to after login
                RedirectUris = { Common.Constants.Url.MvcClientHttps+"signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { Common.Constants.Url.MvcClientHttps+"signout-callback-oidc" },

                //AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    //"api1"
                }
            },
            new Client{
                ClientId="angularClient",
                AllowedGrantTypes=GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret=false,
                RedirectUris={ "http://localhost:4200"},
                PostLogoutRedirectUris={ "http://localhost:4200"},
                AllowedCorsOrigins={ "http://localhost:4200"},
                AllowedScopes={
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "api1.read"
                },
                AllowAccessTokensViaBrowser=true,
                RequireConsent=false
            }
        };
    }
}