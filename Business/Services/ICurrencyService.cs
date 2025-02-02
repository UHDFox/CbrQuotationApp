using Domain;
using Domain.Enums;

namespace Business.Services;

public interface ICurrencyService
{
    public Task<IReadOnlyCollection<Currency>> GetCurrencyListAsync(int offset, int limit);
    
    public Task<Currency> GetCurrencyByCodeAsync(CurrencyCode code);
}