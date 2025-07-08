using MerchantAPI.Application.DependencyInjection;
using MerchantAPI.Infrastructure.DependencyInjection;
using MerchantAPI.WebAPIServer.DependencyInjection;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddWebAPIServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();
app.UseAuthorization();
await app.Services.SeedDatabaseAsync();

app.MapControllers();

app.Run();
