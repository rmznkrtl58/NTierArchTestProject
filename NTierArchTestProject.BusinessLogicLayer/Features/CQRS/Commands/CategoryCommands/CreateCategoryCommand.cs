using MediatR;


namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands
{
    public sealed record class CreateCategoryCommand(string Name):IRequest;
}
