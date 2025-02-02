using Domain;

namespace Business.Services;

public interface ICurrencyService
{
    public Task<IReadOnlyCollection<Currency>> GetAllCurrenciesAsync();
    
    public Task<Currency> GetCurrencyByCodeAsync(string code);
}