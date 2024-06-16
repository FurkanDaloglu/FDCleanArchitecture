using FluentValidation;

namespace FDCleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public sealed class CreateUserRoleCommandValidator:AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(p=>p.AppUserId).NotEmpty().WithMessage("Kullanıcı bilgisi boş olamaz");
        RuleFor(p=>p.AppUserId).NotNull().WithMessage("Kullanıcı bilgisi boş olamaz");

        RuleFor(p => p.RoleId).NotEmpty().WithMessage("Rol bilgisi boş olamaz");
        RuleFor(p => p.RoleId).NotNull().WithMessage("Rol bilgisi boş olamaz");
    }
}


