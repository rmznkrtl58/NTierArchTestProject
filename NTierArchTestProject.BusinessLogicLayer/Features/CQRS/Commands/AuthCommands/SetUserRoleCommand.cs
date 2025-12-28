using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands
{
    public sealed record  SetUserRoleCommand(Guid UserId,Guid RoleId):IRequest<Unit>;

}
