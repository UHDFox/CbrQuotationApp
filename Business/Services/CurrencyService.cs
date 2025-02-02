using AutoMapper;
using Client;
using Domain;
using Domain.Enums;

namespace Business.Services;

public sealed class CurrencyService : ICurrencyService
{
    private readonly CurrencyClient _currencyClient;
    private readonly IMapper _mapper;

    public CurrencyService(CurrencyClient currencyClient, IMapper mapper)
    {
        _currencyClient = currencyClient;
        _mapper = mapper;
    }
    public async Task<IReadOnlyCollection<Currency>> GetCurrencyListAsync(int offset, int limit)
    {
        return  await _currencyClient.GetCurrencyListAsync( offset, limit);
    }

    public async Task<Currency> GetCurrencyByCodeAsync(CurrencyCode code)
    {
        var result = await _currencyClient.GetCurrencyByCodeAsync(code);
        
        return _mapper.Map<Currency>(result);
    }
}