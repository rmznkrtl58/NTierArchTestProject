using FluentValidation;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;


namespace NTierArchTestProject.BusinessLogicLayer.ValidationRules
{
    public sealed class LoginUserValidators:AbstractValidator<LoginCommand>
    {
        public LoginUserValidators()
        {
            RuleFor(p => p.UsernameOrEmail).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.UsernameOrEmail).NotNull().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.UsernameOrEmail).MinimumLength(3).WithMessage("Kullanıcı en az 3 karakter olmalıdır");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şife en az 1 adet büyük harf içermelidir!");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şife en az 1 adet küçük harf içermelidir!");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şife en az 1 adet rakam içermelidir!");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şife en az 1 adet özel karakter içermelidir!");
        }
    }
}
