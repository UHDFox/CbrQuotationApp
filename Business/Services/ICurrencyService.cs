using Domain;
using Domain.Enums;

namespace Business.Services;

public interface ICurrencyService
{
    public Task<IReadOnlyCollection<Currency>> GetAllCurrenciesAsync();
    
    public Task<Currency> GetCurrencyByCodeAsync(CurrencyCode code);
}