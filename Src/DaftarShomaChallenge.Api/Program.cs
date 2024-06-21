using DaftarShomaChallenge.Application;
using DaftarShomaChallenge.Core;
using DaftarShomaChallenge.Infrastructure;
using DaftarShomaChallenge.Common.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// logger config
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services
	.AddDbContextConfig(builder.Configuration);
builder.Services
	.AddApplicationService()
	.AddInfrastructureService()
	.AddCoreService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();