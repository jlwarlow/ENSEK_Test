using MeterAPI.Data;
using MeterAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Processor;

public class MeterReadingProcessor : IMeterReadingProcessor
{
    private readonly ILogger<MeterReadingProcessor> _logger;
    private readonly IMeterContext _meterContext;

    public MeterReadingProcessor(ILogger<MeterReadingProcessor> logger, IMeterContext meterContext)
    {
        _logger = logger;
        _meterContext = meterContext;
    }

    public async Task<int> ProcessReadings(IEnumerable<Contracts.MeterReading> readings)
    {
        try
        {
            int processedCount = 0;

            foreach (var reading in readings)
            {
                // Process each reading here
                _logger.LogInformation($"Processing reading: {reading.MeterReadValue} for AccountId: {reading.AccountId}");

                var account = await _meterContext.Accounts
                    .Where(a => a.AccountId == reading.AccountId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (account == null)
                {
                    _logger.LogWarning($"Account with ID {reading.AccountId} not found. Skipping record.");
                    continue;
                }

                var meterReading = await _meterContext.MeterReadings
                    .Where(m => m.AccountId == reading.AccountId && m.MeterReadingDateTime == reading.MeterReadingDateTime)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (meterReading != null)
                {
                    _logger.LogWarning($"Already have a meter reading for account {reading.AccountId} on {reading.MeterReadingDateTime}, skipping record");
                    continue;
                }

                _meterContext.MeterReadings.Add(new Domain.Entities.MeterReading
                {
                    AccountId = reading.AccountId,
                    MeterReadingDateTime = reading.MeterReadingDateTime,
                    MeterReadValue = reading.MeterReadValue
                });

                _meterContext.SaveChanges();

                processedCount++;
            }
            return processedCount;
        }
        catch(Exception e)
        {
            _logger.LogError(e, "An error occurred while processing meter readings: {Message}", e.Message);
            throw;
        }

    }
}