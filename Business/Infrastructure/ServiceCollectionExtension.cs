using System.Reflection;
using Business.Services;
using Client;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<ICurrencyService, CurrencyService>();
        services.AddTransient<CurrencyClient>();
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}