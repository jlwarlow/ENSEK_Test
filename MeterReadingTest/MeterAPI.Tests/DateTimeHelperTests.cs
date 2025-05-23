using FluentAssertions;
using MeterAPI.Helpers;

namespace MeterAPI.Tests;

public class DateTimeHelperTests
{
    [Test]
    public void DateTimeHelper_CloseTo_Should_Return_True_When_Dates_Are_Close()
    {
        // Arrange
        var dateTime1 = new DateTime(2025, 05, 22, 10, 0, 0);
        var dateTime2 = new DateTime(2025, 05, 22, 10, 0, 3);

       // Act
       var result = dateTime1.CloseTo(dateTime2, 5);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void DateTimeHelper_CloseTo_Should_Return_True_When_Dates_Are_Close_But_DateTime1_Is_Later()
    {
        // Arrange
        var dateTime1 = new DateTime(2025, 05, 22, 10, 0, 3);
        var dateTime2 = new DateTime(2025, 05, 22, 10, 0, 0);

        // Act
        var result = dateTime1.CloseTo(dateTime2, 5);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void DateTimeHelper_CloseTo_Should_Return_False_When_Dates_Are_Not_Close()
    {
        // Arrange
        var dateTime1 = new DateTime(2025, 05, 22, 10, 0, 0);
        var dateTime2 = new DateTime(2025, 05, 22, 10, 0, 10);

        // Act
        var result = dateTime1.CloseTo(dateTime2, 5);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void DateTimeHelper_CloseTo_Should_Return_False_When_Dates_Are_Not_Close_But_DateTime1_Is_Later()
    {
        // Arrange
        var dateTime1 = new DateTime(2025, 05, 22, 10, 0, 10);
        var dateTime2 = new DateTime(2025, 05, 22, 10, 0, 0);

        // Act
        var result = dateTime1.CloseTo(dateTime2, 5);

        // Assert
        result.Should().BeFalse();
    }
}
