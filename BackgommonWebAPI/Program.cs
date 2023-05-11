using DAL.Repositories;
using System.Data.SqlClient;
using System.Data;
using Umbraco.Core.Services.Implement;
using Umbraco.Core.Services;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using BackgommonWebAPI.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//-DAL
builder.Services.AddTransient<IDbConnection, SqlConnection>((service) =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    return new SqlConnection(connectionString);
});
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// - BLL
builder.Services.AddScoped<IPlayerService, PlayerService>();
//// - API Helper
//builder.Services.AddSingleton<JwtHelper>();

//builder.Services.AddSingleton<JwtHelper>();

builder.Services.AddControllers();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
