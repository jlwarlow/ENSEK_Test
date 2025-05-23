namespace MeterAPI.Contracts.Responses;

public class PostMeterReadingsResponse
{
    public int TotalRecords { get; set; }
    public int FailedRecords { get; set; }
}
