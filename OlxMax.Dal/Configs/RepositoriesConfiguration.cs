
using Microsoft.Extensions.DependencyInjection;

using OlxMax.Dal.Repositories;

namespace OlxMax.Dal.Configs
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            //service.AddScoped<IAuctionRepository, AuctionRepository>();
            //service.AddScoped<IBetRepository,BetRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
