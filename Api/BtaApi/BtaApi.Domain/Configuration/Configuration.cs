using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BtaApi.Domain.Configuration
{
    public static class Configuration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<BtaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
