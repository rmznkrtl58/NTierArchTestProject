using NTierArchTestProject.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.DataAccessLayer.UnitOfWorkPattern
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
