using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.DataAccessLayer.Contracts;
using System.Security.Claims;

namespace NTierArchTestProject.WebAPI.Attributes
{
    public sealed class RoleAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;
        private readonly IUserRoleRepository _userRoleRepo;
        public RoleAttribute(string role, IUserRoleRepository userRoleRepo)
        {
            _role = role;
            _userRoleRepo = userRoleRepo;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            //context=>gelen requeste sahip bu request sayesinde kontrol yaptırıp hata varsa hata fırlattırım
            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim is null)
            {
                //401 yetkili değilsin dön
                context.Result = new UnauthorizedResult();
                return;
            }

            var userHasRole = _userRoleRepo
                .GetListByFilter(x => x.AppUserId.ToString() == userIdClaim.Value)
                .Include(p => p.AppRole)
                .Any(y => y.AppRole.Name == _role);

            if (!userHasRole)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

        }
    }
}
