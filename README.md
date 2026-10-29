# ProTeamManagerApi

API REST développée avec ASP.NET Core et .NET 10 pour gérer des équipes de jeux vidéo.

## Fonctionnalités

- **CRUD complet** pour les équipes, les joueurs et les matchs.
- Gestion des relations (un-à-plusieurs) entre les équipes, leurs joueurs et leurs matchs.
- Validation automatique des données entrantes avec FluentValidation.
- Gestion globale des erreurs avec des réponses HTTP structurées (`ProblemDetails`).
- Stockage persistant avec SQLite (approche Code-First et Migrations EF Core).
- Tests automatisés (unitaires avec Moq et d'intégration avec `WebApplicationFactory`).
- Documentation interactive via Swagger / OpenAPI.

## Technologies

- C# et ASP.NET Core 10
- Entity Framework Core 10
- SQLite
- FluentValidation
- Swagger / OpenAPI
- xUnit et Moq

## Prérequis

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Git

## Installation

Cloner le dépôt :

```bash
git clone https://github.com/Bimrane/ProTeamManagerApi.git
cd ProTeamManagerApi
```

Restaurer les dépendances :

```bash
dotnet restore ./ProTeamManagerApi.sln
```

## Lancer l'API

```bash
dotnet run --project ./ProTeamManagerApi.Core/ProTeamManagerApi.Core.csproj
```

Au démarrage, les migrations Entity Framework Core en attente sont appliquées automatiquement.

La base de données SQLite est configurée dans `ProTeamManagerApi.Core/appsettings.json`.

## Documentation Swagger

Une fois l'API lancée en environnement de développement, ouvre l'URL Swagger affichée dans le terminal, généralement :

`https://localhost:5210/swagger`

Swagger permet de consulter les routes et de tester les requêtes HTTP.

## Routes disponibles

| Méthode | Route | Description |
|---|---|---|
| **Équipes** | | |
| GET | `/api/teams` | Récupérer toutes les équipes |
| GET | `/api/teams/{id}` | Récupérer une équipe par son identifiant |
| POST | `/api/teams` | Créer une équipe |
| PUT | `/api/teams/{id}` | Mettre à jour une équipe |
| DELETE | `/api/teams/{id}` | Supprimer une équipe |
| **Joueurs** | | |
| GET | `/api/players` | Récupérer tous les joueurs |
| GET | `/api/players/{id}` | Récupérer un joueur par son identifiant |
| POST | `/api/players` | Créer un joueur |
| PUT | `/api/players/{id}` | Mettre à jour un joueur |
| DELETE | `/api/players/{id}` | Supprimer un joueur |
| **Matchs** | | |
| GET | `/api/matches` | Récupérer tous les matchs |
| GET | `/api/matches/{id}` | Récupérer un match par son identifiant |
| POST | `/api/matches` | Créer un match |
| PUT | `/api/matches/{id}` | Mettre à jour un match |
| DELETE | `/api/matches/{id}` | Supprimer un match |

### Exemple de création d'équipe

Requête `POST /api/teams` avec le corps JSON suivant :

```json
{
  "name": "Mon équipe",
  "game": "League of Legends"
}
```

Réponses possibles :

- `201 Created` : équipe créée.
- `400 Bad Request` : données invalides.
- `404 Not Found` : équipe introuvable pour une recherche par identifiant.

## Tests

Lancer les tests :

```bash
dotnet test ./ProTeamManagerApi.sln
```

## Structure du projet

- `Controllers/` : endpoints HTTP.
- `DTOs/` : objets utilisés pour les requêtes et réponses.
- `Data/` : contexte Entity Framework Core.
- `Models/` : modèles de données.
- `Repositories/` : accès aux données.
- `Services/` : logique métier.
- `Validators/` : règles de validation.
- `Errors/` : gestion globale des erreurs.
- `Migrations/` : historique des évolutions de la base de données.

## Licence

Projet personnel à but pédagogique et de portfolio.
