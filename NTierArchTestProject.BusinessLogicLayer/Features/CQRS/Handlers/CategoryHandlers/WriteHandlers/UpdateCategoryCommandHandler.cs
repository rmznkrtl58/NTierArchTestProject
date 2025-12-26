using AutoMapper;
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
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unifOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unifOfWork = unifOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetValueByFilterAsync(x => x.Id == request.Id,cancellationToken);
            if (category is null) throw new ArgumentException("Kategori Bulunamadı!");
            
            if (category.Name != request.Name)
            {
                var isCategoryNameExist = await _categoryRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
                if (isCategoryNameExist) throw new ArgumentException("Bu kategori daha önce oluşturulmuş");
               
            }

            //category.Name = request.Name;
            //create deki gibi yeni bir instance değilde set etme gibi düşün
            _mapper.Map(request, category);
            await _unifOfWork.CommitAsync(cancellationToken);
        }
    }
}
