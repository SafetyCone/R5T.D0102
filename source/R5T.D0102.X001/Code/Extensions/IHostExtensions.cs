using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using R5T.D0102;


namespace System
{
    public static class IHostExtensions
    {
        public static async Task<IHost> SerializeConfigurationAudit(this Task<IHost> gettingHost)
        {
            var host = await gettingHost;

            await host.SerializeConfigurationAudit();

            return host;
        }

        public static async Task<IHost> SerializeConfigurationAudit(this IHost host)
        {
            var configurationAuditSerializer = host.Services.GetRequiredService<IConfigurationAuditSerializer>();

            await configurationAuditSerializer.SerializeConfiguration();

            return host;
        }
    }
}