using FluentValidation;

namespace FDCleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public sealed class CreateNewTokenByRefreshTokenCommandValidator :AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p=>p.UserId).NotEmpty().WithMessage("User Bilgisi Boş olamaz.");
        RuleFor(p=>p.UserId).NotNull().WithMessage("User Bilgisi Boş olamaz.");
        RuleFor(p=>p.RefreshToken).NotEmpty().WithMessage("Refresh Token Bilgisi Boş olamaz.");
        RuleFor(p=>p.RefreshToken).NotNull().WithMessage("Refresh Token Bilgisi Boş olamaz.");
    }
}

