using ConsumerApi.Extensions;
using ConsumerApi.Services;

var builder = WebApplication.CreateBuilder(args);

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
