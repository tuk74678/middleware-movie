using MovieMiddleware.Filters;
using MovieMiddleware.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        path: "Logs/log-.json",
        rollingInterval: RollingInterval.Day,
        formatter: new Serilog.Formatting.Json.JsonFormatter()
    )
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<LogFilter>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Test log
Log.Information("Application started successfully!");

// Enable Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the  HTTP request pipeline.

// Global Exception Handling Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();