using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;
using static OpenIddict.Abstractions.OpenIddictConstants;
// OpenIddict.EntityFrameworkCore namespaces are available via package references; keep using directives minimal

namespace MicroServiceShop.IdentityServer6.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider provider)
        {
            // touched to force rebuild
            using var scope = provider.CreateScope();
            var sp = scope.ServiceProvider;

            var scopeManager = sp.GetRequiredService<IOpenIddictScopeManager>();
            var appManager = sp.GetRequiredService<IOpenIddictApplicationManager>();

            // Seed scopes
            foreach (var (name, description) in Config.ApiScopes)
            {
                var existing = await scopeManager.FindByNameAsync(name);
                if (existing == null)
                {
                    var descriptor = new OpenIddictScopeDescriptor
                    {
                        Name = name,
                        DisplayName = description
                    };
                    descriptor.Resources.Add(name);
                    await scopeManager.CreateAsync(descriptor);
                }
            }

            // Seed clients
            foreach (var (clientId, secret, scopes, grantTypes) in Config.Clients)
            {
                var existing = await appManager.FindByClientIdAsync(clientId);
                if (existing == null)
                {
                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = clientId,
                        ClientSecret = secret,
                        DisplayName = clientId
                    };

                    // map grant types to permissions
                    foreach (var g in grantTypes)
                    {
                        if (string.Equals(g, GrantTypes.ClientCredentials, StringComparison.OrdinalIgnoreCase))
                        {
                            descriptor.Permissions.Add(Permissions.GrantTypes.ClientCredentials);
                            descriptor.Permissions.Add(Permissions.Endpoints.Token);
                        }
                        else if (string.Equals(g, GrantTypes.Password, StringComparison.OrdinalIgnoreCase))
                        {
                            descriptor.Permissions.Add(Permissions.GrantTypes.Password);
                            descriptor.Permissions.Add(Permissions.Endpoints.Token);
                        }
                        else
                        {
                            // add as raw grant/permission where appropriate
                            descriptor.Permissions.Add(g);
                        }
                    }

                    // scopes -> permissions
                    foreach (var s in scopes)
                    {
                        descriptor.Permissions.Add(Permissions.Prefixes.Scope + s);
                    }

                    await appManager.CreateAsync(descriptor);
                }
            }
        }
    }
}
