using FluentValidation;

namespace FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed class LoginCommandValidator:AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı yada mail bilgisi boş olamaz");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı yada mail bilgisi boş olamaz");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanıcı adı yada mail bilgisi en az 3 karakter olmalıdır");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az bir adet büyük harf içermelidir.");
        RuleFor(p => p.Password).Matches("[a-a]").WithMessage("Şifre en az bir adet küçük harf içermelidir.");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az bir adet sayı içermelidir.");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir adet özel karakter içermelidir.");
    }
}