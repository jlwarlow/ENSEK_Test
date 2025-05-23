using FluentAssertions;
using MeterAPI.Controllers;
using MeterAPI.CSVService;
using MeterAPI.Processor;
using Microsoft.Extensions.Logging;
using Moq;

namespace MeterAPI.Tests;

public class Tests
{
    private Mock<ILogger<Meter>> _mockLogger;
    private Mock<ICSVService> _mockCSVService;
    private Mock<IMeterReadingProcessor> _mockProcessor;

    private Meter _meterReading;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<Meter>>();
        _mockCSVService = new Mock<ICSVService>();
        _mockProcessor = new Mock<IMeterReadingProcessor>(); 
        _meterReading = new Meter(_mockLogger.Object, _mockCSVService.Object, _mockProcessor.Object);
    }

    [Test]
    public void Check_Meter_Reading_Constructed()
    {
        _meterReading.Should().NotBeNull();
    }

    [Test]
    public void Check_Meter_Processes_Valid_Data()
    {
        // Arrange

    }
}