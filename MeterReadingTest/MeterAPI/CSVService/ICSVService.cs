namespace MeterAPI.CSVService;

public interface ICSVService
{
    public (IEnumerable<T> records, int numBadRecords) ReadCSV<T>(Stream file);
}