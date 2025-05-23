namespace MeterAPI.Processor;

public interface IMeterReadingProcessor
{
    public Task<int> ProcessReadings(IEnumerable<Contracts.MeterReading> readings);
}
