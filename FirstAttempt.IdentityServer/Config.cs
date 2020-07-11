// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace FirstAttempt.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("testapi"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "blazor",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedCorsOrigins = {"https://localhost:5002"},

                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = {"https://localhost:5002/authentication/login-callback"},
                    PostLogoutRedirectUris = {"https://localhost:5002/"},

                    AllowedScopes = {"openid", "profile", "email", "testapi" }
                },
            };
    }
}