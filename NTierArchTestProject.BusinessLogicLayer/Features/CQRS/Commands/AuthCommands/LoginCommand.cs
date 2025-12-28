using MediatR;
using NTierArchTestProject.BusinessLogicLayer.DataTransferObjects;


namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands
{
    public sealed record  LoginCommand(string UsernameOrEmail,string Password):IRequest<UserLoginResponse>;
}
