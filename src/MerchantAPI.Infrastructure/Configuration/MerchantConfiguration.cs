using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MerchantAPI.Infrastructure.Configuration
{
    internal sealed class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.BusinessName)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(m => m.Country)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(m => m.CreatedAt)
                .IsRequired();
            builder.Property(m=>m.Status).HasConversion<string>().IsRequired();
            builder.HasIndex(m => m.BusinessName).IsUnique();
        }
    }
}
