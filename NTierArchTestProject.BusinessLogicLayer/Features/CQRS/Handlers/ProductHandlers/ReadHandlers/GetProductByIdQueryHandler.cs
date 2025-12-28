using AutoMapper;
using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.ProductQueries;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.ProductResults;
using NTierArchTestProject.DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.ProductHandlers.ReadHandlers
{
    internal sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _pRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository pRepository, IMapper mapper)
        {
            _pRepository = pRepository;
            _mapper = mapper;
        }
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var findValue = await _pRepository.GetValueByFilterAsync(x=>x.Id==request.Id);
            if (findValue is null) throw new KeyNotFoundException($"{request.Id}'ye ait ürün bulunamadı");
            var mapValue = _mapper.Map<GetProductByIdQueryResult>(findValue);
            return mapValue;
        }
    }
}
