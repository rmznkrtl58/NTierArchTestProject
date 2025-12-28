using MediatR;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.AuthHandlers.WriteHandlers
{
    internal sealed class SetUserRoleCommandHandler : IRequestHandler<SetUserRoleCommand, Unit>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SetUserRoleCommandHandler(IUserRoleRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkUserRoleIsExist = await _userRoleRepository.AnyAsync(x => x.AppUserId == request.UserId && x.AppRoleId == request.RoleId,cancellationToken);
            if (checkUserRoleIsExist) throw new ArgumentException("Kullanıcı Bu role zaten sahiptir.");

            var userRole = new UserRole()
            {
                AppRoleId = request.RoleId,
                AppUserId = request.UserId,
            };

            await _userRoleRepository.CreateAsync(userRole, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
