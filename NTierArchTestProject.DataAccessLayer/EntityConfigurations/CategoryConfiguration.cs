using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchTestProject.NTierArchTestProject.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.DataAccessLayer.EntityConfigurations
{
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Category Sınıfım Sql'de Categories olarak gözükecek
            builder.ToTable("Categories");
            builder.Property(x => x.Name).HasColumnType("varchar(100)");
            //PrimaryKey
            builder.HasKey(x => x.Id);
        }
    }
}
