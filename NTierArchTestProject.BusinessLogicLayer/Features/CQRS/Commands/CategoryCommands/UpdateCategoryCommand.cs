using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands
{
    public record class UpdateCategoryCommand(Guid Id,string Name):IRequest;
}
