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
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _pRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IProductRepository pRepository, IUnitOfWork unitOfWork)
        {
            _pRepository = pRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _pRepository.GetValueByFilterAsync(x => x.Id == request.Id, cancellationToken);
            if (product is null) throw new ArgumentException("Ürün Bulunamadı!");

            if (product.Name != request.Name)
            {
                var isProductNameExist = await _pRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
                if (isProductNameExist) throw new ArgumentException("Bu Ürün daha önce oluşturulmuş");

                product.Name = request.Name;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;
                product.Quantity = request.Quantity;
                await _unitOfWork.CommitAsync(cancellationToken);
            }
        }
    }
}
