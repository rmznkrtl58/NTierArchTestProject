using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.DataAccessLayer.EntityConfigurations
{
    internal sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles");
            builder.HasKey(p => new{ p.AppUserId,p.AppRoleId});//ikili kullanım
        }
    }
}
