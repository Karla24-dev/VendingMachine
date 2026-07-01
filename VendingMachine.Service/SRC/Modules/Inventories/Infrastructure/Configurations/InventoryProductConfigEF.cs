using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using VendingMachine.Inventories.Domain;
using VendingMachine.Products.Domain;

namespace VendingMachine.Inventories.Infraestructure;

public class InventoryProductConfigEF : IEntityTypeConfiguration<InventoryProduct>
{
    public void Configure(EntityTypeBuilder<InventoryProduct> entity)
    {
        entity.ToTable("inventory_product");
        entity.HasKey(ip => ip.Id);
        entity.Property(ip => ip.Id).ValueGeneratedNever();

        entity.Property(ip => ip.InventoryId).IsRequired();
        entity.Property(ip => ip.ProductId).IsRequired();
        entity.Property(ip => ip.CurrentStock).IsRequired();
        entity.Property(ip => ip.MinStock).IsRequired();

        entity.Property(ip => ip.Row);
        entity.Property(ip => ip.Column);

        // relaciones
        entity.HasOne<Inventory>()
            .WithMany()
            .HasForeignKey(ip => ip.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne<Product>()
            .WithMany()
            .HasForeignKey(ip => ip.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasIndex(ip => new { ip.InventoryId, ip.ProductId }).IsUnique();
    }
}
