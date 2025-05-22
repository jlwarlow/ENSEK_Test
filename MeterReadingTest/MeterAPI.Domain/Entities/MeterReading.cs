namespace MeterAPI.Domain.Entities;

public class MeterReading
{
    public int AccountId { get; set; }
    public DateTime MeterReadingDateTime { get; set; }
    public int MeterReadValue { get; set; }
}
