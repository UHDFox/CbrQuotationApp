namespace CbrQuotationApp.Contracts.Responses;

public class CurrencyInfoResponse
{
    public string Id { get; set; }
    public string NumCode { get; set; }
    public string CharCode { get; set; }
    public int Nominal { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public decimal Previous { get; set; }
    
    public CurrencyInfoResponse(string id, string numCode, string charCode, int nominal,string name, decimal value, decimal previous)
    {
        Id = id;
        NumCode = numCode;
        CharCode = charCode;
        Nominal = nominal;
        Name = name;
        Value = value;
        Previous = previous;
    }
}