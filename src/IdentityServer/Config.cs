// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids
        {
            get
            {
                var profileResource = new IdentityResources.Profile();
                profileResource.UserClaims.Add("eye_colour");
                var resources = new List<IdentityResource> { new IdentityResources.OpenId(), profileResource };
                return resources;
            }
        }


        public static IEnumerable<ApiResource> Apis
        {
            get
            {
              //  var apiResource = new ApiResource("api1", "My API");
                var resources = new List<ApiResource>
                {
                   
                };
                return resources;
            }
        }
     

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // machine to machine client
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                
                    // where to redirect to after login
                    RedirectUris = { "http://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "eye_colour"
                    },
                    
                    AllowOfflineAccess = true
                }
            };
    }
}