using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;


namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.ProductHandlers.WriteHandlers
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,ErrorOr<Unit>>
    {
        private readonly IProductRepository _pRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository pRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _pRepository = pRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isProductNameExist = await _pRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (isProductNameExist) return Error.Conflict("NameIsExist","Bu Ürün Daha önce oluşturulmuş");

            var createValue= _mapper.Map<Product>(request);
            await _pRepository.CreateAsync(createValue, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;//boş bir cevap dönderir yapı gereği mutlaka böyle yazılmalı
        }
    }
}
