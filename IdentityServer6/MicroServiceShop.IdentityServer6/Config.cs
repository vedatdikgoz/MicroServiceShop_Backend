using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MicroServiceShop.IdentityServer6
{
    public static class Config
    {
        // Map IdentityServer config to OpenIddict: define scopes and clients via seed or database.
        public const string LocalApiScope = "microserviceshop_local_api";

        public static IEnumerable<(string Name, string Description)> ApiScopes =>
            new[]
            {
                ("catalog_fullpermission","Catalog API için tam erişim"),
                ("photo_fullpermission","Photo API için tam erişim"),
                ("basket_fullpermission","Basket API için tam erişim"),
                ("discount_fullpermission","Discount API için tam erişim"),
                ("order_fullpermission","Order API için tam erişim"),
                ("payment_fullpermission","Payment API için tam erişim"),
                ("gateway_fullpermission","Gateway API için tam erişim"),
                ("comment_fullpermission","Comment API için tam erişim"),
                ("message_fullpermission","Message API için tam erişim"),
                ("cargo_fullpermission","Cargo API için tam erişim"),
                ("a_fullpermission","Invoice API için tam erişim"),
                (LocalApiScope, "Local API scope")
            };

        public static IEnumerable<(string ClientId, string Secret, string[] Scopes, string[] GrantTypes)> Clients =>
            new[]
            {
                ("VisitorClient", "microserviceshopsecret", new[] {"catalog_fullpermission","comment_fullpermission","gateway_fullpermission", LocalApiScope}, new[] {GrantTypes.ClientCredentials}),
                ("AdminClient", "microserviceshopsecret", new[] {"catalog_fullpermission","photo_fullpermission","comment_fullpermission","basket_fullpermission","order_fullpermission","discount_fullpermission","message_fullpermission","cargo_fullpermission","payment_fullpermission","a_fullpermission","gateway_fullpermission", Scopes.Email, Scopes.OpenId, Scopes.Profile, Scopes.OfflineAccess, LocalApiScope, "roles"}, new[] {GrantTypes.Password}),
                ("TokenExchangeClient", "microserviceshopsecret", new[] {"discount_fullpermission","payment_fullpermission", Scopes.OpenId}, new[] {"urn:ietf:params:oauth:grant-type:token-exchange"})
            };

    }
}
