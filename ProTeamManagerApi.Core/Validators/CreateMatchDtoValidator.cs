using FluentValidation;
using ProTeamManagerApi.Core.DTOs;

namespace ProTeamManagerApi.Core.Validators;

public class CreateMatchDtoValidator : AbstractValidator<CreateMatchDto>
{
    public CreateMatchDtoValidator()
    {
        RuleFor(x => x.Opponent)
            .NotEmpty().WithMessage("Le nom de l'adversaire est obligatoire.");

        RuleFor(x => x.Tournament)
            .NotEmpty().WithMessage("Le nom du tournoi est obligatoire.");

        RuleFor(x => x.MatchDate)
            .NotEmpty().WithMessage("La date du match est obligatoire.");

        RuleFor(x => x.TeamScore)
            .GreaterThanOrEqualTo(0).WithMessage("Le score de l'équipe ne peut pas être négatif.");

        RuleFor(x => x.OpponentScore)
            .GreaterThanOrEqualTo(0).WithMessage("Le score de l'adversaire ne peut pas être négatif.");

        RuleFor(x => x.TeamId)
            .GreaterThan(0).WithMessage("L'identifiant de l'équipe est invalide.");
    }
}