using Client;
using Client.Options;
using Domain.Enums;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

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

    public static IServiceCollection ConfigureSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SchemaFilter<EnumSchemaFilter>();
            c.MapType<CurrencyCode>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = Enum.GetNames(typeof(CurrencyCode))
                    .Select(name => new OpenApiString(name))
                    .ToList<IOpenApiAny>()
            });
        });
        
        return services;
    }

}