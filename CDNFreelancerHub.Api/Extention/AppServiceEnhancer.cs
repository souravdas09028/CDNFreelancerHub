using CDNFreelancerHub.Core.Data;
using CDNFreelancerHub.Service.Implementations;
using CDNFreelancerHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CDNFreelancerHub.Api.Extention
{
    public static class AppServiceEnhancer
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<CDNFreelancerHubDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
