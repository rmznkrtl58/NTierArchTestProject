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
        public GetAllCategoryQueryResultHandler(ICategoryRepository cRepository)
        {
            _cRepository = cRepository;
        }
        public async Task<IEnumerable<GetAllCategoryQueryResult>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _cRepository.GetListAll().OrderBy(c=>c.Name).ToListAsync();
            return values.Select(x => new GetAllCategoryQueryResult(x.Id, x.Name));
        }
    }
}
