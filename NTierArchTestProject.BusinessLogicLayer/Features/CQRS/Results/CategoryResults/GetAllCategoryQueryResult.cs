using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.CategoryQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.CategoryResults
{
    internal sealed record class GetAllCategoryQueryResult(Guid Id,string Name);
}
