using MeterAPI.Contracts.Responses;
using Newtonsoft.Json;

namespace MeterReadingApp.Client;

public class MeterReadingClient : IMeterReadingClient
{
    private static HttpClient _client = new()
    {
        BaseAddress = new Uri("https://localhost:7186/"),
    };

    public async Task<PostMeterReadingsResponse> PostMeterReadings(byte[] csvContent)
    {
        var byteArray = new ByteArrayContent(csvContent);
        var multipartContent = new MultipartFormDataContent();
        multipartContent.Add(byteArray, "file", "meterreading.csv");
        var response = await _client.PostAsync("meter-reading-uploads", multipartContent);
        if (response.IsSuccessStatusCode)
        {
            var resposeBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PostMeterReadingsResponse>(resposeBody)!;
        }

        throw new InvalidOperationException($"Error posting meter readings: {response.StatusCode} - {response.ReasonPhrase}");
    }
}
