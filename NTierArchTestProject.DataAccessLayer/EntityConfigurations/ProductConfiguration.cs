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
    internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasColumnType("money");
        }
    }
}
