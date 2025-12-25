using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.CategoryHandlers.WriteHandlers
{
    internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _cRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler(ICategoryRepository cRepository, IUnitOfWork unitOfWork)
        {
            _cRepository = cRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var findValue = await _cRepository.GetValueByFilterAsync(x => x.Id == request.Id);
            if (findValue is null) throw new ArgumentException($"{request.Id}'ye ait kategori bulunmamıştır");
            _cRepository.Delete(findValue);
            await _unitOfWork.CommitAsync();
        }
    }
}
