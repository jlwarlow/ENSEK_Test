using MeterAPI.Contracts.Responses;
using MeterAPI.CSVService;
using MeterAPI.Processor;
using Microsoft.AspNetCore.Mvc;

namespace MeterAPI.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class Meter(ILogger<Meter> logger, ICSVService csvService, IMeterReadingProcessor meterReadingProcessor) : ControllerBase
    {
        private readonly ILogger<Meter> _logger = logger;
        private readonly ICSVService _csvService = csvService;
        private readonly IMeterReadingProcessor _readingProcessor = meterReadingProcessor;

        [HttpPost]
        public async Task<ActionResult<PostMeterReadingsResponse>> PostMeterReadings([FromForm] IFormFile file)
        {
            try
            {
                var result = _csvService.ReadCSV<Contracts.MeterReading>(file.OpenReadStream());
                if (result.records.Count() == 0 && result.numBadRecords != 0)
                {
                    return BadRequest(new { message = $"{result.numBadRecords} Bad records found out of {result.numBadRecords + result.records.Count()} Total Records" });
                }

                var processedRecords = await _readingProcessor.ProcessReadings(result.records);

                var totalRecords = result.records.Count() + result.numBadRecords;
                var response = new PostMeterReadingsResponse
                {
                    TotalRecords = totalRecords,
                    FailedRecords = totalRecords - processedRecords // Failed records are those bad from CSV or duplicates not processed
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
