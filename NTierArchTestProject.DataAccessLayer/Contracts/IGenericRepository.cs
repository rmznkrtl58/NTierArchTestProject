
using System.Linq.Expressions;

namespace NTierArchTestProject.DataAccessLayer.Contracts
{
    public interface IGenericRepository<T>where T:class
    {
        //Read
        IQueryable<T> GetListByFilter(Expression<Func<T, bool>> condition);
        IQueryable<T> GetListAll();
        Task<T> GetValueByFilterAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken=default);//default=>isterse verilmeyebilir
        //Create
        Task CreateAsync(T t,CancellationToken cancellationToken=default);
        //Update
        void Update(T t);
        //Delete
        void Delete(T t);
        //Check
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);//ilgili şarta göre mevcut mu? mevcutsa true değilse false
    }
}