using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchTestProject.BusinessLogicLayer.Events;
using NTierArchTestProject.BusinessLogicLayer.Events.UserEvents;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.AuthHandlers.WriteHandlers
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMediator _mediator;
        public RegisterCommandHandler(UserManager<AppUser> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //var isUsernameExist = await _userManager.Users.AnyAsync(x => x.UserName != request.Username && x.Email != request.Email);
            var checkUsernameExist = await _userManager.FindByNameAsync(request.Username);
            if (checkUsernameExist is not null) throw new ArgumentException($"'{request.Username}' => kullanıcı adı daha önce kullanılmıştır.");
            var checkEmailExist=await _userManager.FindByEmailAsync(request.Email);
            if (checkUsernameExist is not null) throw new ArgumentException($"'{request.Email}' => eposta adresi daha önce kullanılmıştır.");
            
            var createUser = new AppUser()
            {
                Email = request.Email,
                UserName = request.Username,
                NameSurname = request.NameSurname,
                Id = Guid.NewGuid()
            };
            await _userManager.CreateAsync(createUser,request.Password);

            //Event tabanlı çağırma
            await _mediator.Publish(new UserDomainEvent(createUser));

            return Unit.Value;
        }
    }
}
