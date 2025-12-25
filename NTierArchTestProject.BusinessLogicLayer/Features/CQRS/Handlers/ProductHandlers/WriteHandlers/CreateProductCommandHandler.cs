using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.ProductHandlers.WriteHandlers
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _pRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository pRepository, IUnitOfWork unitOfWork)
        {
            _pRepository = pRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isProductNameExist = await _pRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (isProductNameExist) throw new ArgumentException("Bu Ürün Daha önce oluşturulmuş");

            var createValue = new Product()
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price,
                Quantity = request.Quantity,
            };
            await _pRepository.CreateAsync(createValue, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
