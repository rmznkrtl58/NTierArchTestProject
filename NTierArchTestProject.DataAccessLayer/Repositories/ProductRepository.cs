using NTierArchTestProject.DataAccessLayer.Context;
using NTierArchTestProject.DataAccessLayer.Contracts;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;


namespace NTierArchTestProject.DataAccessLayer.Repositories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
