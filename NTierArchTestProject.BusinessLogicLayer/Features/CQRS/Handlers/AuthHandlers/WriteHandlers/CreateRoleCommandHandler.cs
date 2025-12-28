using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Handlers.AuthHandlers.WriteHandlers
{
    internal sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var checkRoleIsExist = await _roleRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (checkRoleIsExist) throw new ArgumentException("Bu rol daha önce oluşturulmuş.");

            var appRole = new AppRole()
            {
                Name = request.Name,
                Id = Guid.NewGuid()
            };
            await _roleRepository.CreateAsync(appRole,cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
