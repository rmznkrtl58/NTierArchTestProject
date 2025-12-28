using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.AuthResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.AuthQueries
{
    public sealed record GetAllRoleQuery:IRequest<IEnumerable<GetAllRoleQueryResult>>
    {
    }
}
