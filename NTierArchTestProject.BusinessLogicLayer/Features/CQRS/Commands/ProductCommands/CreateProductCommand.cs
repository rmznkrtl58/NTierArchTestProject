using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands
{
    internal sealed record class CreateProductCommand(string Name, decimal Price, int Quantity, Guid CategoryId):IRequest;
}
