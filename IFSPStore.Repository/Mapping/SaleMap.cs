using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStore.Repository.Mapping
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SaleDate);
            builder.Property(p => p.SaleTotal);
            builder.HasOne(p => p.Salesman);
            builder.HasOne(p => p.Customer);
            builder.HasMany(p => p.SaleItens)
                .WithOne(p => p.Sale)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class SaleItemMap : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItem");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantity);
            builder.Property(p => p.UnitPrice);
            builder.Property(p => p.TotalPrice);
            builder.HasOne(p => p.Product);
            builder.HasOne(p => p.Sale)
                .WithMany(p => p.SaleItens)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
