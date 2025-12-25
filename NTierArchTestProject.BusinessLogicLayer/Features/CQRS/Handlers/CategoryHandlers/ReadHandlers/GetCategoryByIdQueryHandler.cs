using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.CategoryQueries;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.CategoryResults;
using NTierArchTestProject.DataAccessLayer.Contracts;


namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.CategoryHandlers.ReadHandlers
{
    internal sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _cRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository cRepository)
        {
            _cRepository = cRepository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var findValue = await _cRepository.GetValueByFilterAsync(x => x.Id == request.Id, cancellationToken);
            if (findValue is null)throw new KeyNotFoundException($"{request.Id}'ye ait kategori bulunamadı!");
            return new GetCategoryByIdQueryResult(findValue.Id, findValue.Name);
        }
    }
}
