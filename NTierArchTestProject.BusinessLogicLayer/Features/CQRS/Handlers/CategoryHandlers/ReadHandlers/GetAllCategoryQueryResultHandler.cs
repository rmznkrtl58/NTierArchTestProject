using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.CategoryQueries;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.CategoryResults;
using NTierArchTestProject.DataAccessLayer.Contracts;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.CategoryHandlers.ReadHandlers
{
    internal class GetAllCategoryQueryResultHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<GetAllCategoryQueryResult>>
    {
        private readonly ICategoryRepository _cRepository;
        private readonly IMapper _mapper;
        public GetAllCategoryQueryResultHandler(ICategoryRepository cRepository, IMapper mapper)
        {
            _cRepository = cRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllCategoryQueryResult>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _cRepository.GetListAll().OrderBy(c=>c.Name).ToListAsync();
            var mapValue =_mapper.Map<IEnumerable<GetAllCategoryQueryResult>>(values);
            return mapValue;
        }
    }
}
