using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.ProductResults
{
    internal sealed record class GetAllProductQueryResult(Guid Id,string Name,decimal Price,int Quantity,Guid CategoryId);
}
