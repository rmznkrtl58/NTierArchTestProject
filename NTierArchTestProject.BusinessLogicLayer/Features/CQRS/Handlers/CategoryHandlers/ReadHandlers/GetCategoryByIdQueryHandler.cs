using AutoMapper;
using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.CategoryQueries;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.CategoryResults;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;


namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.CategoryHandlers.ReadHandlers
{
    internal sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly ICategoryRepository _cRepository;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(ICategoryRepository cRepository, IMapper mapper)
        {
            _cRepository = cRepository;
            _mapper = mapper;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var findValue = await _cRepository.GetValueByFilterAsync(x => x.Id == request.Id, cancellationToken);
            if (findValue is null)throw new KeyNotFoundException($"{request.Id}'ye ait kategori bulunamadı!");
            var mapValue = _mapper.Map<GetCategoryByIdQueryResult>(findValue);
            return mapValue;
        }
    }
}
