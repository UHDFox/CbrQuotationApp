using Business.Services;
using CbrQuotationApp.Contracts.Responses;
using Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CbrQuotationApp.Controllers;

[Controller]
[Route("api/v1/[controller]")]
public class CurrencyController : Controller
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }
    
    [HttpGet("GetByCode")]
    public async Task<IActionResult> GetCurrencyByCode([FromQuery] CurrencyCode code)
    {
        var result = await _currencyService.GetCurrencyByCodeAsync(code);
        
        return Ok(new CurrencyInfoResponse
            (result.Id, result.NumCode, result.CharCode, result.Nominal, result.Name, result.Value, result.Previous));
    }

    [HttpGet("GetPage")]
    public async Task<IActionResult> GetCurrenciesList(int? offset, int? limit)
    {
        var result = await 
            _currencyService.GetCurrencyListAsync(offset.GetValueOrDefault(0), limit.GetValueOrDefault(5));

        return Ok(result);
    }
}