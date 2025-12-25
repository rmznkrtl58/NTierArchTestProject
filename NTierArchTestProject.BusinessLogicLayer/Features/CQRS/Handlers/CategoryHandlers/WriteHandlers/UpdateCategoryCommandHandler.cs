using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;


namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.CategoryHandlers.WriteHandlers
{
    internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unifOfWork;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unifOfWork)
        {
            _categoryRepository = categoryRepository;
            _unifOfWork = unifOfWork;
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetValueByFilterAsync(x => x.Id == request.Id,cancellationToken);
            if (category is null) throw new ArgumentException("Kategori Bulunamadı!");
            
            if (category.Name != request.Name)
            {
                var isCategoryNameExist = await _categoryRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
                if (isCategoryNameExist) throw new ArgumentException("Bu kategori daha önce oluşturulmuş");

                category.Name = request.Name;

                await _unifOfWork.CommitAsync(cancellationToken);
            }
        }
    }
}
