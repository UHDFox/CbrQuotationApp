using AutoMapper;
using Client;
using Domain;

namespace Business.Services;

public class CurrencyService : ICurrencyService
{
    private readonly CurrencyClient _currencyClient;
    private readonly IMapper _mapper;

    public CurrencyService(CurrencyClient currencyClient, IMapper mapper)
    {
        _currencyClient = currencyClient;
        _mapper = mapper;
    }
    public Task<IReadOnlyCollection<Currency>> GetAllCurrenciesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Currency> GetCurrencyByCodeAsync(string code)
    {
        var result = await _currencyClient.GetCurrencyByCodeAsync(code);
        
        return _mapper.Map<Currency>(result);
    }
}