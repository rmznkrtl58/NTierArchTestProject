using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Results.AuthResults
{
    public sealed record  GetAllRoleQueryResult(Guid Id,string Name);
}
