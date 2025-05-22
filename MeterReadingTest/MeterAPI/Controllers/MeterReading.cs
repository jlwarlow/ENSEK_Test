using Microsoft.AspNetCore.Mvc;

namespace MeterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeterReading : ControllerBase
    {
        private readonly ILogger<MeterReading> _logger;

        public MeterReading(ILogger<MeterReading> logger)
        {
            _logger = logger;
        }
    }
}
