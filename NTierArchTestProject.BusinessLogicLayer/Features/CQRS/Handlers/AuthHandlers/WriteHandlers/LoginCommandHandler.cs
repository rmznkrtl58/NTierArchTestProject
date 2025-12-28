using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.BusinessLogicLayer.Abstractions;
using NTierArchTestProject.BusinessLogicLayer.DataTransferObjects;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.AuthHandlers.WriteHandlers
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, UserLoginResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtProvider _jwtProvider;
        public LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }
        public async Task<UserLoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = await _userManager.Users.Where(x => x.UserName == request.UsernameOrEmail || x.Email == request.UsernameOrEmail).FirstOrDefaultAsync(cancellationToken);
            if (appUser is null) throw new ArgumentException("Şifre Veya Kullanıcı Adı Yanlıştır!");

            bool checkPassword = await _userManager.CheckPasswordAsync(appUser, request.Password);
            if(!checkPassword) throw new ArgumentException("Şifre Veya Kullanıcı Adı Yanlıştır!");

            string token = await _jwtProvider.CreateTokenAsync(appUser);
            return new UserLoginResponse(token,appUser.Id);
        }
    }
}
