using CDNFreelancerHub.Web.Services.Implementations;
using CDNFreelancerHub.Web.Services.Interfaces;

namespace CDNFreelancerHub.Web.Extentions
{
    public static class AppServiceEnhancer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFreelancerService, FreelancerService>();
        }
    }
}
