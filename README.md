# ProTeamManagerApi

API REST développée avec ASP.NET Core et .NET 10 pour gérer des équipes de jeux vidéo.

## Fonctionnalités

- Consulter la liste des équipes.
- Consulter les détails d'une équipe.
- Créer une équipe.
- Valider les données reçues avec FluentValidation.
- Gérer les erreurs avec des réponses HTTP structurées.
- Stocker les données dans une base SQLite.
- Documenter et tester l'API avec Swagger.

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

`https://localhost:<PORT>/swagger`

Swagger permet de consulter les routes et de tester les requêtes HTTP.

## Routes disponibles

| Méthode | Route | Description |
|---|---|---|
| GET | `/api/teams` | Récupérer toutes les équipes |
| GET | `/api/teams/{id}` | Récupérer une équipe par son identifiant |
| POST | `/api/teams` | Créer une équipe |

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
