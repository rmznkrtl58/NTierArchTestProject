using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.ProductQueries;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.ProductResults;
using NTierArchTestProject.DataAccessLayer.Contracts;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.ProductHandlers.ReadHandlers
{

    internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<GetAllProductQueryResult>>
    {
        private readonly IProductRepository _pRepository;

        public GetAllProductQueryHandler(IProductRepository pRepository)
        {
            _pRepository = pRepository;
        }

        public async Task<IEnumerable<GetAllProductQueryResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var values = await _pRepository.GetListAll().OrderBy(x => x.Id).ToListAsync();
            return values.Select(x => new GetAllProductQueryResult(x.Id, x.Name, x.Price, x.Quantity, x.CategoryId));
        }
    }
}
