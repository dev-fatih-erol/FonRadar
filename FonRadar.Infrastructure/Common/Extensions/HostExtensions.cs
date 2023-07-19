using FonRadar.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FonRadar.Infrastructure.Common.Extensions
{
    public static class HostExtensions
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();

                seeder.Seed().Wait();
            }

            return host;
        }
    }
}

