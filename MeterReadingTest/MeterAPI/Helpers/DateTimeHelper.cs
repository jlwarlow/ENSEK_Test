namespace MeterAPI.Helpers;

public static class DateTimeHelper
{
    public static bool CloseTo(this DateTime dateTime1, DateTime datetime2, double secondsToCompare)
    {
        var difference = datetime2 - dateTime1;
        if (double.Abs(difference.TotalSeconds) <= secondsToCompare)
        {
            return true;
        }

        return false;
    }
}
