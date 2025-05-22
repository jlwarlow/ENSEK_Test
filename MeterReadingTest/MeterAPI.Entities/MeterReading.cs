namespace MeterAPI.Entities;

public record MeterReading
{
    public int AccountId { get; set; }
    public DateTime MeterReadingDateTime { get; set; }
    public int MeterReadValue { get; set; }
}