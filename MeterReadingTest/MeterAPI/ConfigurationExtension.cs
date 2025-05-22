using Microsoft.Data.SqlClient;

namespace MeterAPI;

public static class ConfigurationExtension
{
    public static string GetSqlConnectionString(this IConfiguration configuration, string name, string assemblyName)
    {
        SqlConnectionStringBuilder builder = new(configuration.GetConnectionString(name))
        {
            ApplicationName = $"{assemblyName}_{configuration.GetComponentVersion()}"
        };

        return builder.ToString();
    }
    public static string? GetComponentVersion(this IConfiguration configuration)
        => configuration.GetValue("AppSettings:ComponentVersion", "Version Unconfigured");
}
