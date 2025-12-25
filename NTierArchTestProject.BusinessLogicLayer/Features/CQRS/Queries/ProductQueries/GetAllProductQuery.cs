using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.ProductResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.ProductQueries
{
    internal sealed class GetAllProductQuery:IRequest<IEnumerable<GetAllProductQueryResult>>
    {
    }
}
