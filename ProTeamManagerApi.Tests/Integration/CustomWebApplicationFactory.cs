using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using ProTeamManagerApi.Core.Data;

namespace ProTeamManagerApi.Tests.Integration;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly SqliteConnection _connection;

    public CustomWebApplicationFactory()
    {
        // Crée une base SQLite en mémoire persistante pour la durée des tests
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        
        builder.ConfigureServices(services =>
        {
            // Supprime l'enregistrement réel du DbContext (SQLite fichier)
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<ProTeamManagerDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Remplace par la base SQLite en mémoire de test
            services.AddDbContext<ProTeamManagerDbContext>(options =>
            {
                options.UseSqlite(_connection);
            });

            // Crée le schéma de la base de données pour les tests
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ProTeamManagerDbContext>();
            db.Database.EnsureCreated();
        });
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        _connection.Dispose();
    }
}