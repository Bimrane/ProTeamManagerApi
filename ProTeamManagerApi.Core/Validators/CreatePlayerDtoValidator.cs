using FluentValidation;
using ProTeamManagerApi.Core.DTOs;

namespace ProTeamManagerApi.Core.Validators;

public class CreatePlayerDtoValidator : AbstractValidator<CreatePlayerDto>
{
    public CreatePlayerDtoValidator()
    {
        RuleFor(x => x.Nickname)
            .NotEmpty().WithMessage("Le nickname du joueur est obligatoire.")
            .MaximumLength(30).WithMessage("Le nickname ne peut pas dépasser 30 caractères.");

        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Le rôle du joueur est obligatoire.");

        RuleFor(x => x.TeamId)
            .GreaterThan(0).WithMessage("L'identifiant de l'équipe est invalide.");
    }
}