using MeterAPI;
using MeterAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddDbContext<MeterContext>(options => options.UseSqlServer(
            configuration.GetSqlConnectionString("MeterReadings", GetExecutingAssemblyName())));
}
static string GetExecutingAssemblyName()
{
    return Assembly.GetExecutingAssembly().GetName().Name ?? throw new ArgumentNullException("GetExecutingAssemblyName");
}