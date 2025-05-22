using FluentAssertions;
using MeterAPI.Controllers;
using Microsoft.Extensions.Logging;
using Moq;

namespace MeterAPI.Tests;

public class Tests
{
    private Mock<ILogger<MeterReading>> _mockLogger;
    private MeterReading _meterReading;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<MeterReading>>();
        _meterReading = new MeterReading(_mockLogger.Object);
    }

    [Test]
    public void Check_Meter_Reading_Constructed()
    {
        _meterReading.Should().NotBeNull();
    }
}