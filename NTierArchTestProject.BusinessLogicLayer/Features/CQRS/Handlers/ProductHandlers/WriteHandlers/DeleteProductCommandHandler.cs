using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.ProductHandlers.WriteHandlers
{
    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _pRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository pRepository, IUnitOfWork unitOfWork)
        {
            _pRepository = pRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var findValue = await _pRepository.GetValueByFilterAsync(x => x.Id == request.Id);
            if (findValue is null) throw new KeyNotFoundException($"{request.Id}'ye ait Ürün yoktur");
            _pRepository.Delete(findValue);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
