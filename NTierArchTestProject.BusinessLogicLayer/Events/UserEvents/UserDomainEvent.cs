

using MediatR;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;

namespace NTierArchTestProject.BusinessLogicLayer.Events.UserEvents
{
    public sealed class UserDomainEvent : INotification//MediatR kütüphanesini kullanarak bu classın bir event olduğunu gösterir
    {
        public AppUser AppUser { get; }
        public UserDomainEvent(AppUser AppUser)
        {
            this.AppUser = AppUser;
        }
    }

}
