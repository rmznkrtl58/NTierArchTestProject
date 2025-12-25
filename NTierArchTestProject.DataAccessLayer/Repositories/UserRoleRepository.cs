using NTierArchTestProject.DataAccessLayer.Context;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.DataAccessLayer.Repositories
{
    internal class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
