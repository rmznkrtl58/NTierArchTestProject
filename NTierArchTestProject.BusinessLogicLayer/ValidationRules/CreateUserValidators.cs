using FluentValidation;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;

namespace NTierArchTestProject.BusinessLogicLayer.ValidationRules
{
    public sealed class CreateUserValidators:AbstractValidator<RegisterCommand>
    {
        public CreateUserValidators()
        {
            RuleFor(p => p.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.Username).NotNull().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.Username).MinimumLength(3).WithMessage("Kullanıcı en az 3 karakter olmalıdır");
            RuleFor(p => p.NameSurname).NotEmpty().WithMessage("Ad Soyad alanı boş olamaz");
            RuleFor(p => p.NameSurname).NotNull().WithMessage("Ad Soyad alanı boş olamaz");
            RuleFor(p => p.NameSurname).MinimumLength(3).WithMessage("Ad Soyad alanı en az 3 karakter olmalıdır");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail adresi boş olamaz");
            RuleFor(p => p.Email).NotNull().WithMessage("Mail adresi boş olamaz");
            RuleFor(p => p.Email).MinimumLength(3).WithMessage("Mail adresi en az 3 karakter olmalıdır");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi girin");
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
