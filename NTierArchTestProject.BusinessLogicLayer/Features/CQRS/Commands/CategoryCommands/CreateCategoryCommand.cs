using ErrorOr;
using MediatR;


namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands
{
    public sealed record class CreateCategoryCommand(string Name):IRequest<ErrorOr<Unit>>;//Unit Boş bir değer olarak algılar validation behaviorda hep bir değer beklediğimiz için böyle yazdık aslında önemli değil ama yapının çalışması için gerekli
}
