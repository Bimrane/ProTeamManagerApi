using ProTeamManagerApi.Core.Data;
using Microsoft.EntityFrameworkCore;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using ProTeamManagerApi.Core.Errors;

var builder = WebApplication.CreateBuilder(args);

// 1. Ajouter les services au conteneur d'injection de dependances
builder.Services.AddControllers();

// 2. Configurer la documentation Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProTeamManagerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// 3. Configurer le pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

// 4. Associer les contrôleurs aux routes HTTP
app.MapControllers();

app.Run();
