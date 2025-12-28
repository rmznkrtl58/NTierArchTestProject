using NTierArchTestProject.DataAccessLayer.Identity.Entities;
namespace NTierArchTestProject.BusinessLogicLayer.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
