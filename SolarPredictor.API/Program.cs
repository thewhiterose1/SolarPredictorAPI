using MediatR;
using SolarPredictor.Common.Interface;
using SolarPredictor.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddTransient<ITelemetryRepository, TelemetryRepository>();

string cs = Environment.GetEnvironmentVariable("APPCONFIG_CONNECTION");

if (!string.IsNullOrEmpty(cs))
{
    builder.Configuration.AddAzureAppConfiguration(cs);
}

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
