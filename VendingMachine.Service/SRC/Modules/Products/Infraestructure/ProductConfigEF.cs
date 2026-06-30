using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Inventories.Domain;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Infraestructure;

public class ProductConfigEF : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.ToTable("products");
        entity.HasKey(p => p.Id);
        entity.Property(p => p.Id).ValueGeneratedNever();

        entity.Property(p => p.Name).IsRequired().HasMaxLength(150);
        entity.Property(p => p.Reference).IsRequired().HasMaxLength(50);

        entity.Property(p => p.PackageBag)
            .HasConversion<string>()
            .IsRequired();

        entity.Property(p => p.PackageType)
            .HasConversion<string>()
            .IsRequired();

        entity.Property(p => p.PurchasePrice).HasPrecision(10, 2).IsRequired();
        entity.Property(p => p.SalePrice).HasPrecision(10, 2).IsRequired();
        entity.Property(p => p.ProfitPercentage).HasPrecision(5, 2).IsRequired();

        entity.Property(p => p.ImageUrl).IsRequired(false);
        entity.HasIndex(p => p.Reference).IsUnique();

    }
}
