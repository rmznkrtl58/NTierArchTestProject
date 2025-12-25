
using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.CategoryHandlers.WriteHandlers
{
    internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isCategoryNameExist = await _categoryRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (isCategoryNameExist) throw new ArgumentException("Bu kategori Daha önce oluşturulmuş");

            var createValue = new Category()
            {
                Name = request.Name
            };

            await _categoryRepository.CreateAsync(createValue,cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
