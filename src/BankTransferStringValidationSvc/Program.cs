using System.Reflection;
using Defender.MarkII.BankTransferStringValidationSvc.Infrastructure;
using Defender.MarkII.BankTransferStringValidationSvc.Services;
using Defender.MarkII.BankTransferStringValidationSvc.ValidationServices;
using Microsoft.ApplicationInsights.Extensibility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddSingleton<ITelemetryInitializer, ApplicationMapNodeNameInitializer>();
builder.Services.RegisterAllTypes<IStringValidationSvc>(new[] { Assembly.GetExecutingAssembly() }, ServiceLifetime.Scoped);
builder.Services.AddScoped<IValidationSvc, ValidationSvc>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterValidationEndpoint();

app.UseAuthorization();

app.MapControllers();

app.Run();