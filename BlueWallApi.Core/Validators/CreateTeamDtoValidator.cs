using FluentValidation;
using BlueWallApi.Core.DTOs;

namespace BlueWallApi.Core.Validators;

public class CreateTeamDtoValidator : AbstractValidator<CreateTeamDto>
{
    public CreateTeamDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Le nom de l'équipe est obligatoire.")
            .MaximumLength(50).WithMessage("Le nom ne peut pas dépasser 50 caractères.");

        RuleFor(x => x.Game)
            .NotEmpty().WithMessage("Le nom du jeu (ex: League of Legends) est obligatoire.");
    }
}