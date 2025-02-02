namespace Client.Responses;

public sealed class ApiResponse
{
    public DateTime Date { get; set; }
    public DateTime PreviousDate { get; set; }
    public string PreviousUrl { get; set; }
    public DateTime Timestamp { get; set; }
    
    public Dictionary<string, CurrencyInfo> Valute { get; set; } = new Dictionary<string, CurrencyInfo>();

    public ApiResponse(DateTime date, DateTime previousDate, string previousUrl, DateTime timestamp)
    {
        Date = date;
        PreviousDate = previousDate;
        PreviousUrl = previousUrl;
        Timestamp = timestamp;
    }
}