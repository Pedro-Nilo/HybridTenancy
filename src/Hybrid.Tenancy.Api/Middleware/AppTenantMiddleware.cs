using Hybrid.Tenancy.Api.Models.Commom;
using SaasKit.Multitenancy;

namespace Hybrid.Tenancy.Api.Middleware;

public class AppTenantMiddleware : ITenantResolver<AppTenant>
{
    public Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
    {
        const string defaultHeader = "tenant-id";

        if (context.Request.Headers.ContainsKey(defaultHeader))
        {
            var appTenant = new AppTenant(Guid.Parse(context.Request.Headers[defaultHeader]));
            var TenantContext = new TenantContext<AppTenant>(appTenant);

            return Task.FromResult(TenantContext);
        }

        return Task.FromResult<TenantContext<AppTenant>>(null);
    }
}
