using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands
{
    public sealed record class CreateProductCommand(string Name, decimal Price, int Quantity, Guid CategoryId):IRequest<ErrorOr<Unit>>;//Unit Boş bir değer olarak algılar validation behaviorda hep bir değer beklediğimiz için böyle yazdık aslında önemli değil ama yapının çalışması için gerekli
}

