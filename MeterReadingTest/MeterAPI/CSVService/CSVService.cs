using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace MeterAPI.CSVService;

public class CSVService : ICSVService
{
    public (IEnumerable<T> records, int numBadRecords) ReadCSV<T>(Stream file)
    {
        var records = new List<T>();
        int numberOfBadRecords = 0;
        var config = new CsvConfiguration(CultureInfo.GetCultureInfo("en-GB"))
        {
            HasHeaderRecord = true,
            ReadingExceptionOccurred = context => 
            {
                numberOfBadRecords++;
                return false; // Skip the record
            },
        };

        using var reader = new StreamReader(file);
        using var csv = new CsvReader(reader, config);
        csv.Context.RegisterClassMap<MeterReadingMap>();
        records = csv.GetRecords<T>().ToList();
        return (records, numberOfBadRecords);
    }
}

internal class MeterReadingMap : ClassMap<Contracts.MeterReading>
{
    public MeterReadingMap()
    {
        Map(m => m.MeterReadingDateTime)
            .TypeConverter<DateTimeConverter>()
            .TypeConverterOption.Format("dd/MM/yyyy hh:mm");
        Map(m => m.AccountId).Name("AccountId");
        Map(m => m.MeterReadValue).Name("MeterReadValue");
    }
}