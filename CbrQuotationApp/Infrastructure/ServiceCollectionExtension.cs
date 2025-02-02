using Client;
using Client.Options;
using Microsoft.Extensions.Options;

namespace CbrQuotationApp.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ConfigureCurrencyClient(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.Configure<CurrencyClientOptions>(configuration.GetSection("CurrencyClient"));
        
        services.AddHttpClient<CurrencyClient>((serviceProvider, httpClient) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<CurrencyClientOptions>>().Value;
            
            httpClient.BaseAddress = new Uri(settings.ApiUrl);  // Используем ApiUrl из настроек
        });
        
        services.AddTransient<Business.Services.ICurrencyService, Business.Services.CurrencyService>();

        return services;
    }
}