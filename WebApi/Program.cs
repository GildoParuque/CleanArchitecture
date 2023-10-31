using Application;
using Infrastructure;
using Presetation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Add the Layers
builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresetation();

builder.Host.UseSerilog((context, config) =>
        config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
