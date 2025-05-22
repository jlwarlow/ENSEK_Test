namespace MeterAPI.Contracts;

public record MeterReading
{
    public int AccountId { get; set; }
    public DateTime MeterReadingDateTime { get; set; }
    public int MeterReadValue { get; set; }

    public virtual Account? Account { get; set; } = null!;
}