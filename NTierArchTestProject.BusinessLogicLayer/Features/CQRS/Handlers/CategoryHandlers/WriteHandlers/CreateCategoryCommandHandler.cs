
using AutoMapper;
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
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isCategoryNameExist = await _categoryRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (isCategoryNameExist) throw new ArgumentException("Bu kategori Daha önce oluşturulmuş");

            //yeni bir instance türetir 
            var createValue = _mapper.Map<Category>(request);

            await _categoryRepository.CreateAsync(createValue,cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
