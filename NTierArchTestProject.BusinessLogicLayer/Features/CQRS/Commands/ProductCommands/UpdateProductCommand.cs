using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands
{

    public sealed record class UpdateProductCommand(Guid Id, string Name, decimal Price, int Quantity, Guid CategoryId):IRequest;
}


