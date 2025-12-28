using Microsoft.AspNetCore.Mvc;

namespace NTierArchTestProject.WebAPI.Attributes
{
    public sealed class RoleFilterAttribute : TypeFilterAttribute
    {
        public RoleFilterAttribute(string role) : base(typeof(RoleAttribute))
        {
            Arguments=new object[] {role};
        }
    }
}
