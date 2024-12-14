using Boonkrua.Data.Features.Notifications.Repositories;
using Boonkrua.Data.Features.Topics.Interfaces;
using Boonkrua.Data.Features.Topics.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Boonkrua.IoC.Configuration.DependencyInjections;

public static partial class ServiceExtensions
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
        services.AddScoped<ConfigRepository, ConfigRepository>();
    }
}
