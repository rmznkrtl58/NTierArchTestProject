using FluentValidation;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands;


namespace NTierArchTestProject.BusinessLogicLayer.ValidationRules
{
    internal sealed class CategoryValidators:AbstractValidator<CreateCategoryCommand>
    {  //şimdilik ekleme için kullanıyorum
        public CategoryValidators()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kategori adı boş olamaz");
            RuleFor(p => p.Name).NotNull().WithMessage("Kategori adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır");
            RuleFor(p => p.Name).MaximumLength(20).WithMessage("Kategori adı en fazla 20 karakter olmalıdır");
        }
    }
}
