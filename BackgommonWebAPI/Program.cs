using DAL.Repositories;
using System.Data.SqlClient;
using System.Data;
using Umbraco.Core.Services.Implement;
using Umbraco.Core.Services;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using BackgommonWebAPI.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//-DAL
builder.Services.AddTransient<IDbConnection, SqlConnection>((service) =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    return new SqlConnection(connectionString);
});
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

// - BLL
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

//// - API Helper
builder.Services.AddSingleton<JwtHelper>();

// Ajout des controllers de l'API
builder.Services.AddControllers();

// Ajout de la configuration pour l'authentification
builder.Services
    // - Active le Jwt Bearer
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // - Configuration du check du JWT
    .AddJwtBearer(options =>
    {
        // Sauvegarde du token si celui-ci est valide
        options.SaveToken = true;

        // Parametre à validé dans le token
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            // Issuer
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            // Audience
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            // Durée du vie
            ValidateLifetime = true,
            // Signature
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])
            )
        };
    });

// La doc Swagger
// - Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Ajout de la doc pour swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UserApi DevOps",
        Description = "Exemple d'API pour les DevOps de Techni",
    });

    // Ajout de l'authentification dans swagger
    // - Bouton pour se connecter sur l'interface
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Entrer votre JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    // - Lock sur les routes (Toutes les routes...)
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
