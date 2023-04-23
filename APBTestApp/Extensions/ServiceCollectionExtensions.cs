using ABPTestApp.Infrastructure.Extensions;

namespace APBTestApp.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure(builder.Configuration);
        }
    }
}
