using Microsoft.AspNetCore.Identity;


namespace NTierArchTestProject.DataAccessLayer.Identity.Entities
{
    public sealed class AppUser:IdentityUser<Guid>
    {
        public string NameSurname { get; set; }
    }
}
