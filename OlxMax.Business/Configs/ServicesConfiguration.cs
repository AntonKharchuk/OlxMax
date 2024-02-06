
using Microsoft.Extensions.DependencyInjection;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Business.FeatureServices.Realizations;

namespace OlxMax.Business.Configs
{
    public static class ServicesConfiguration
    {
        public static void AddCustomServices(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
        }
    }
}
