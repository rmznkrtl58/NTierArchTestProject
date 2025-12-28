using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository pRepository, IMapper mapper)
        {
            _pRepository = pRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllProductQueryResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var values = await _pRepository.GetListAll().OrderBy(x => x.Id).ToListAsync();
            var mapValue = _mapper.Map<IEnumerable<GetAllProductQueryResult>>(values);
            return mapValue;
        }
    }
}
