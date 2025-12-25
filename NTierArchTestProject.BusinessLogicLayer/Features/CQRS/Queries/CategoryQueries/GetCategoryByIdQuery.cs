using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.CategoryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.CategoryQueries
{
    internal sealed class GetCategoryByIdQuery:IRequest<GetCategoryByIdQueryResult> 
    {
        public Guid Id { get; set; }
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
