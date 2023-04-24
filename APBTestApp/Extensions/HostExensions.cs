using ABPTestApp.Infrastructure.Persistance;
using ABPTestApp.Infrastructure.Persistance.DataSeed;

namespace ABPTestApp.API.Extensions
{
    public static class HostExensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ExperimentDbContext>();

                await ExperimentsSeed.Seed(context);
            }
        }
    }
}
