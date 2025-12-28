using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.DataAccessLayer.Context
{
    public sealed class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {//Model Builder->entitiylerimizi database bağlamak hemde alanları özelleştirmek için

            //Projem büyük kapsamda olmadığı ve bunlara ihtiyacım olmadığından db'ye eklemiyorum
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
            //Dal projemdeki configuration classlarını okur ve implement eder.
            builder.ApplyConfigurationsFromAssembly(typeof(DalAssembly).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
