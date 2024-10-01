using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MicroServiceShop.IdentityServer6
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
         [
            new ApiResource("resource_catalog") {Scopes = {"catalog_fullpermission"}},
            new ApiResource("resource_photo") {Scopes = {"photo_fullpermission"}},
            new ApiResource("resource_basket") {Scopes = {"basket_fullpermission"}},
            new ApiResource("resource_discount") {Scopes = {"discount_fullpermission"}},
            new ApiResource("resource_order") {Scopes = {"order_fullpermission"}},
            new ApiResource("resource_payment") {Scopes = {"payment_fullpermission"}},
            new ApiResource("resource_gateway") {Scopes = {"gateway_fullpermission"}},
            new ApiResource("resource_comment") {Scopes = {"comment_fullpermission"}},
            new ApiResource("resource_message") {Scopes = {"message_fullpermission"}},
            new ApiResource("resource_cargo") {Scopes = {"cargo_fullpermission"}},
            new ApiResource("resource_a") {Scopes = {"a_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
         ];

        public static IEnumerable<IdentityResource> IdentityResources =>
                   [
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
                   ];

        public static IEnumerable<ApiScope> ApiScopes =>
            [
                new ApiScope("catalog_fullpermission","Catalog API için tam erişim"),
                new ApiScope("photo_fullpermission","Photo API için tam erişim"),
                new ApiScope("basket_fullpermission","Basket API için tam erişim"),
                new ApiScope("discount_fullpermission","Discount API için tam erişim"),
                new ApiScope("order_fullpermission","Order API için tam erişim"),
                new ApiScope("payment_fullpermission","Payment API için tam erişim"),
                new ApiScope("gateway_fullpermission","Gateway API için tam erişim"),
                new ApiScope("comment_fullpermission","Comment API için tam erişim"),
                new ApiScope("message_fullpermission","Message API için tam erişim"),
                new ApiScope("cargo_fullpermission","Cargo API için tam erişim"),
                new ApiScope("a_fullpermission","Invoice API için tam erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            ];

        public static IEnumerable<Client> Clients =>
            [
                new Client
                {
                    ClientName = "Visitor",
                    ClientId = "VisitorClient",
                    ClientSecrets = {new Secret("microserviceshopsecret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "catalog_fullpermission",
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
                        "photo_fullpermission",
                        "comment_fullpermission",
                        "basket_fullpermission",
                        "order_fullpermission",
                        "discount_fullpermission",
                        "message_fullpermission",
                        "cargo_fullpermission",
                        "payment_fullpermission",
                        "a_fullpermission",
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
            ];

    }
}
