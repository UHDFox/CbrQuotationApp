using AutoMapper;
using Client;
using Domain;
using Domain.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace Business.Services;

public sealed class CurrencyService : ICurrencyService
{
    private readonly CurrencyClient _currencyClient;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _memoryCache;

    public CurrencyService(CurrencyClient currencyClient, IMapper mapper, IMemoryCache memoryCache)
    {
        _currencyClient = currencyClient;
        _mapper = mapper;
        _memoryCache = memoryCache;
    }
    public async Task<IReadOnlyCollection<Currency>> GetCurrencyListAsync(int offset, int limit)
    {
        var cacheKey = $"CurrencyListPage-{offset}-{limit}";

        if (!_memoryCache.TryGetValue(cacheKey, out IReadOnlyCollection<Currency> currencies))
        {
            var currencyList = await _currencyClient.GetCurrencyListAsync(offset, limit);
            
            var cacheOpts = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(24)); // цб обновляет данные раз в сутки

            _memoryCache.Set(cacheKey, currencyList, cacheOpts);
        }
        return currencies;
    }

    public async Task<Currency> GetCurrencyByCodeAsync(CurrencyCode code)
    {
        var cacheKey = $"currency:{code}";
        
        if (!_memoryCache.TryGetValue(cacheKey, out Currency currency))
        {
            currency = _mapper.Map<Currency>(await _currencyClient.GetCurrencyByCodeAsync(code));
            
            var cacheOpts = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(24)); // цб обновляет данные раз в сутки
            
            _memoryCache.Set(cacheKey, currency, cacheOpts);
        }
        
        return currency;
    }
}