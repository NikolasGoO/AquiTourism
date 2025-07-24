using AquiTourism.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureSerilog();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.ConfigureStartupConfiuration(builder.Configuration);

var app = builder.Build();

app.UseStartupConfiguration(); 

app.Run();
