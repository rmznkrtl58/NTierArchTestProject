using NTierArchTestProject.DataAccessLayer.Context;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.DataAccessLayer.Repositories
{
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
