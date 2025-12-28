using FluentValidation;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;

namespace NTierArchTestProject.BusinessLogicLayer.ValidationRules
{
    internal sealed class CreateRoleValidators:AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidators()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Role adı boş olamaz");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Role adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Role adı 3 karakterden küçük olamaz");
        }
    }
}
