using Microsoft.Extensions.DependencyInjection;
using TLabApp.Application.Service.Contracts;
using TLabApp.Application.Service.IContracts;
using TLabApp.Infrastructure.Persistence;

namespace TLabApp.Application.DependencyServices;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDependencyResolver(this IServiceCollection services)
    {
        services.AddSingleton<AppDbContext>();
        services.AddTransient<ICommonService, CommonService>();



        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}