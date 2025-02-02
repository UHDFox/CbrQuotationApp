using System.Net.Http.Json;
using Client.Options;
using Client.Responses;
using Domain;
using Domain.Enums;
using Microsoft.Extensions.Options;

namespace Client;

public sealed class CurrencyClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public CurrencyClient(HttpClient httpClient, IOptions<CurrencyClientOptions> options)//Todo:IOptions<CurrencyApiSettings> options)
    {
        _httpClient = httpClient;
        _apiUrl = options.Value.ApiUrl;
    }

    public async Task<IReadOnlyCollection<Currency>> GetCurrenciesAsync()
    {
        _httpClient.BaseAddress = new Uri(_apiUrl);
        
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>(_apiUrl);
        return response?.Valute?.Select(kv => new Currency
        {
            Id = kv.Key,
            NumCode = kv.Value.NumCode,
            CharCode = kv.Value.CharCode,
            Nominal = kv.Value.Nominal,
            Name = kv.Value.Name,
            Value = kv.Value.Value, 
            Previous = kv.Value.Previous,
        }).ToList() ?? new List<Currency>();
    }


    public async Task<CurrencyInfo> GetCurrencyByCodeAsync(CurrencyCode code)
    {
        _httpClient.BaseAddress = new Uri(_apiUrl);
        
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>(_apiUrl);

        return response?.Valute[code.ToString()]
               ?? throw new Exception($"Currency with such code not found {code}");
    }
}