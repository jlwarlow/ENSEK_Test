using FluentAssertions;
using MeterAPI.Controllers;
using MeterAPI.CSVService;
using Microsoft.Extensions.Logging;
using Moq;

namespace MeterAPI.Tests;

public class Tests
{
    private Mock<ILogger<MeterReading>> _mockLogger;
    private Mock<ICSVService> _mockCSVService;

    private MeterReading _meterReading;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<MeterReading>>();
        _mockCSVService = new Mock<ICSVService>();
        _meterReading = new MeterReading(_mockLogger.Object, _mockCSVService.Object);
    }

    [Test]
    public void Check_Meter_Reading_Constructed()
    {
        _meterReading.Should().NotBeNull();
    }
}