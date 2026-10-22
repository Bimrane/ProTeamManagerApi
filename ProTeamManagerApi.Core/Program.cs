using ProTeamManagerApi.Core.Data;
using Microsoft.EntityFrameworkCore;
using ProTeamManagerApi.Core.Repositories;
using ProTeamManagerApi.Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using ProTeamManagerApi.Core.Errors;

var builder = WebApplication.CreateBuilder(args);

// 1. Ajouter les services nécessaires à l'application
builder.Services.AddControllers();

// 2. Activer la documentation de l'API avec Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configurer la connexion à la base de données SQLite
builder.Services.AddDbContext<ProTeamManagerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 4. Enregistrer les services et les dépôts utilisés par l'application
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

// 5. Enregistrer les validateurs pour vérifier les données reçues
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// 6. Gérer les erreurs globales et formater les réponses d'erreur
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// 7. Configurer les outils de développement (pipeline HTTP)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 8. Appliquer la gestion globale des erreurs
app.UseExceptionHandler();

// 9. Forcer l'utilisation de HTTPS
app.UseHttpsRedirection();

// 10. Activer la vérification des autorisations
app.UseAuthorization();

// 11. Relier les routes HTTP aux contrôleurs
app.MapControllers();

app.Run();