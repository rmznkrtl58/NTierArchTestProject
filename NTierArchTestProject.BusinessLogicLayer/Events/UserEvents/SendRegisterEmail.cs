using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Events.UserEvents
{
    public sealed class SendRegisterEmail : INotificationHandler<UserDomainEvent>
    {
        //Mail gönderme işlemi
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
