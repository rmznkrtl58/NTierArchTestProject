using MediatR;

namespace NTierArchTestProject.BusinessLogicLayer.Events.UserEvents
{
    public sealed class SendRegisterSms : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            //Sms gönderme işlemi
            return Task.CompletedTask;
        }
    }
}
