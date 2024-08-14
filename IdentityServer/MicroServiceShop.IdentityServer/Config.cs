using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace MicroServiceShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
         {
            new ApiResource("resource_catalog") {Scopes = {"catalog_fullpermission"}},
            new ApiResource("resource_photo_stock") {Scopes = {"photo_stock_fullpermission"}},
            new ApiResource("resource_basket") {Scopes = {"basket_fullpermission"}},
            new ApiResource("resource_discount") {Scopes = {"discount_fullpermission"}},
            new ApiResource("resource_order") {Scopes = {"order_fullpermission"}},
            new ApiResource("resource_payment") {Scopes = {"payment_fullpermission"}},
            new ApiResource("resource_gateway") {Scopes = {"gateway_fullpermission"}},
            new ApiResource("resource_comment") {Scopes = {"comment_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
         };

        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                       new IdentityResources.OpenId(),
                       new IdentityResources.Profile(),
                       new IdentityResource()
                       {
                           Name = "roles",
                           DisplayName = "Roles",
                           Description = "Kullanıcı rolleri",
                           UserClaims = new []{"role"}
                       }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission","Catalog API için tam erişim"),
                new ApiScope("photo_stock_fullpermission","PhotoStock API için tam erişim"),
                new ApiScope("basket_fullpermission","Basket API için tam erişim"),
                new ApiScope("discount_fullpermission","Discount API için tam erişim"),
                new ApiScope("order_fullpermission","Order API için tam erişim"),
                new ApiScope("payment_fullpermission","Payment API için tam erişim"),
                new ApiScope("gateway_fullpermission","Gateway API için tam erişim"),
                new ApiScope("comment_fullpermission","Comment API için tam erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "Visitor",
                    ClientId = "VisitorClient",
                    ClientSecrets = {new Secret("microserviceshopsecret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "catalog_fullpermission",
                        "photo_stock_fullpermission",
                        "comment_fullpermission",
                        "gateway_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName
                    }

                },
                new Client
                {
                    ClientName = "Admin",
                    ClientId = "AdminClient",
                    AllowOfflineAccess = true,
                    ClientSecrets = {new Secret("microserviceshopsecret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        "catalog_fullpermission",
                        "comment_fullpermission",
                        "basket_fullpermission",
                        "order_fullpermission",
                        "gateway_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "roles"
                    },
                    AccessTokenLifetime = 3600,
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = 3600,
                    RefreshTokenUsage = TokenUsage.ReUse

                },
                new Client
                {
                    ClientName="Token Exchange Client",
                    ClientId="TokenExchangeClient",
                    ClientSecrets= {new Secret("microserviceshopsecret".Sha256())},
                    AllowedGrantTypes= new []{ "urn:ietf:params:oauth:grant-type:token-exchange" },
                    AllowedScopes=
                    { 
                        "discount_fullpermission", 
                        "payment_fullpermission", 
                        IdentityServerConstants.StandardScopes.OpenId 
                    }
                }
            };

    }
}