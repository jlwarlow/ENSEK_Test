using MeterAPI.CSVService;
using Microsoft.AspNetCore.Mvc;

namespace MeterAPI.Controllers
{
    [ApiController]
    [Route("meter-reading-uploads")]
    public class MeterReading(ILogger<MeterReading> logger, ICSVService csvService) : ControllerBase
    {
        private readonly ILogger<MeterReading> _logger = logger;
        private readonly ICSVService _csvService = csvService;

        [HttpPost]
        public async Task<IActionResult> PostMeterReadings([FromBody] IFormFileCollection file)
        {
            var result = _csvService.ReadCSV<Entities.MeterReading>(file[0].OpenReadStream());
            if (result.numBadRecords != 0)
            {
                return BadRequest(new { message = $"{result.numBadRecords} Bad records found out of {result.numBadRecords + result.records.Count()} Total Records"});
            }
            await Task.CompletedTask;
            return Ok();
        }
    }
}
