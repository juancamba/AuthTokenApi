using ConsumerApi.Extensions;
using ConsumerApi.Services;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Net.Http.Headers;
using Serilog;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
 try
{
    Log.Information("starting server.");
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
        loggerConfiguration.WriteTo.Console();
        loggerConfiguration.ReadFrom.Configuration(context.Configuration);
    });
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    // PARA INYECTAR LOS SERVICES lo hace con estas clases , asi no sobrecarga progrma.cs
    builder.Services.AddHttpClient();
    builder.Services.AddTransient<AuthService>();
    builder.Services.AddIdentityServices(builder.Configuration);


   
    var app = builder.Build();
    // para que muestre las request
    app.UseSerilogRequestLogging();

    
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    // autenticacion basada en token
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}