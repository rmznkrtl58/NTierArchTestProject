using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.DataAccessLayer.Context;
using NTierArchTestProject.DataAccessLayer.Contracts;
using System.Linq.Expressions;

namespace NTierArchTestProject.DataAccessLayer.Repositories
{
    internal  class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Any(filter);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            var anyStatus = await _context.Set<T>().AnyAsync(filter, cancellationToken);
            return anyStatus;
        }

        public async Task CreateAsync(T t, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(t,cancellationToken);
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public  IQueryable<T> GetListAll()
        {
            var values = _context.Set<T>().AsNoTracking().AsQueryable();
            return values;
        }

        public IQueryable<T> GetListByFilter(Expression<Func<T, bool>> condition)
        {
            var values = _context.Set<T>().AsNoTracking().Where(condition).AsQueryable();
            return values;
        }

        public async Task<T> GetValueByFilterAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
        {
            var value = await _context.Set<T>().Where(filter).FirstOrDefaultAsync(cancellationToken);
            return value;
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
        }
    }
}
