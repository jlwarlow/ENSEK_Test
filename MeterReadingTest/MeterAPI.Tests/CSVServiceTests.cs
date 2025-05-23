using FluentAssertions;
using MeterAPI.CSVService;
using System.Text;

namespace MeterAPI.Tests;

public class CSVServiceTests
{
    private ICSVService _csvService;
    
    [SetUp]
    public void Setup()
    {
        _csvService = new CSVService.CSVService();
    }

    [Test]
    public void CSVService_Should_Process_Valid_CSV()
    {
        // Arrange
        var csvData = "AccountId,MeterReadingDateTime,MeterReadValue,\r\n2344,22/04/2019 09:24,1002,";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(csvData));
        
        // Act
        var (records, numBadRecords) = _csvService.ReadCSV<Contracts.MeterReading>(stream);
        
        // Assert
        records.Should().HaveCount(1);
        numBadRecords.Should().Be(0);
    }

    [Test]
    public void CSVService_Should_Process_InValid_CSV()
    {
        // Arrange
        var csvData = "AccountId,MeterReadingDateTime,MeterReadValue,\r\n2344,22/04/2019 09:24,1002,\r\n2355,fred,1\r\n23";
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(csvData));

        // Act
        var (records, numBadRecords) = _csvService.ReadCSV<Contracts.MeterReading>(stream);

        // Assert
        records.Should().HaveCount(1);
        numBadRecords.Should().Be(2);
    }
}