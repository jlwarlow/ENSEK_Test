using FluentAssertions;
using MeterAPI.Data;
using MeterAPI.Processor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterAPI.Tests;

public class MeterReadingProcessorTests
{
    private Mock<ILogger<MeterReadingProcessor>> _mockLogger;
    private Mock<IMeterContext> _mockMeterContext;

    private IMeterReadingProcessor _meterReadingProcessor;

    [SetUp]
    public void Setup()
    {
        _mockLogger = new Mock<ILogger<MeterReadingProcessor>>();
        _mockMeterContext = new Mock<IMeterContext>();
        _meterReadingProcessor = new MeterReadingProcessor(_mockLogger.Object, _mockMeterContext.Object);
    }

    [Test]
    public async Task MeterReaderProcess_Should_Process_Valid_Data()
    {
        // Arrange
        var readings = new List<Contracts.MeterReading>
        {
            new()
            {
                AccountId = 1234,
                MeterReadingDateTime = DateTime.Parse("22/04/2019 09:24"),
                MeterReadValue = 1002
            },
            new()
            {
                AccountId = 1235,
                MeterReadingDateTime = DateTime.Parse("22/04/2019 09:25"),
                MeterReadValue = 1003
            }
        };

        _mockMeterContext.Setup(m => m.Accounts)
            .ReturnsDbSet(new List<Domain.Entities.Account>
        {
            new() { AccountId = 1234, FirstName = "John", LastName = "Doe" },
            new() { AccountId = 1235, FirstName = "Jane", LastName = "Doe" }
        }.AsQueryable());

        _mockMeterContext.Setup(m => m.MeterReadings)
            .ReturnsDbSet(new List<Domain.Entities.MeterReading>().AsQueryable());

        // Act
        var result = await _meterReadingProcessor.ProcessReadings(readings);

        // Assert
        result.Should().Be(2);
    }

    [Test]
    public async Task MeterReaderProcess_Should_Skip_Duplicate_Data()
    {
        // Arrange
        var readings = new List<Contracts.MeterReading>
        {
            new()
            {
                AccountId = 1234,
                MeterReadingDateTime = DateTime.Parse("22/04/2019 09:24"),
                MeterReadValue = 1002
            },
            new()
            {
                AccountId = 1235,
                MeterReadingDateTime = DateTime.Parse("22/04/2019 09:25"),
                MeterReadValue = 1003
            }
        };

        _mockMeterContext.Setup(m => m.Accounts)
            .ReturnsDbSet(new List<Domain.Entities.Account>
        {
            new() { AccountId = 1234, FirstName = "John", LastName = "Doe" },
            new() { AccountId = 1235, FirstName = "Jane", LastName = "Doe" }
        }.AsQueryable());

        _mockMeterContext.Setup(m => m.MeterReadings)
            .ReturnsDbSet(new List<Domain.Entities.MeterReading>
                {
                new()
                {
                    AccountId = 1235,
                    MeterReadingDateTime = DateTime.Parse("22/04/2019 09:25"),
                    MeterReadValue = 1003
                }
            }.AsQueryable());

        // Act
        var result = await _meterReadingProcessor.ProcessReadings(readings);

        // Assert
        result.Should().Be(1);
    }
}
