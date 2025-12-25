using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands
{
    internal sealed class DeleteProductCommand:IRequest
    {
        public Guid Id { get; set; }
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
