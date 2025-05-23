using MeterAPI.Contracts.Responses;

namespace MeterReadingApp.Client;

public interface IMeterReadingClient
{
    public Task<PostMeterReadingsResponse> PostMeterReadings(byte[] csvContent);
}
