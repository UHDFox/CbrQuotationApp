namespace CbrQuotationApp.Contracts.Responses;

public class CurrencyResponse
{
    public DateTime Date { get; set; }
    public DateTime PreviousDate { get; set; }
    public string PreviousUrl { get; set; }
    public DateTime Timestamp { get; set; }
    
    public Dictionary<string, CurrencyInfoResponse> Valute { get; set; } = 
        new Dictionary<string, CurrencyInfoResponse>();

    public CurrencyResponse(DateTime date, DateTime previousDate, string previousUrl, DateTime timestamp)
    {
        Date = date;
        PreviousDate = previousDate;
        PreviousUrl = previousUrl;
        Timestamp = timestamp;
    }
}