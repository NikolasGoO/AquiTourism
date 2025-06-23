using AquiTourism.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureSerilog();

builder.Services.ConfigureStartupConfiuration(builder.Configuration);

var app = builder.Build();
app.UseStartupConfiguration();

app.Run();