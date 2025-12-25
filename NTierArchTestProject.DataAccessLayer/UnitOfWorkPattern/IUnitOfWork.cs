using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        //SaveChangesAsync ismini yazma sebebim->EfCoreda bu metodun karşılığı var eşitleme yapacağız ilerde bunuda kullanabiliriz ama ben öğrendiğim yolla gideyim 
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Commit();
    }
}
