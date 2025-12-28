using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.AuthQueries;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.AuthResults;
using NTierArchTestProject.DataAccessLayer.Contracts;
namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.AuthHandlers.ReadHandlers
{
    internal sealed class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IEnumerable<GetAllRoleQueryResult>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public GetAllRoleQueryHandler(IRoleRepository roleManager, IMapper mapper)
        {
            _roleRepository = roleManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllRoleQueryResult>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var values = await _roleRepository.GetListAll().OrderBy(x=>x.Name).ToListAsync(cancellationToken);
            var mapValue = _mapper.Map<IEnumerable<GetAllRoleQueryResult>>(values);
            return mapValue;
        }
    }
}
