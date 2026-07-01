using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Products.Domain;

namespace VendingMachine.Products.Infraestructure;

public class ProducComponentCofigEF: IEntityTypeConfiguration<ProductComponent>
{
    public void Configure(EntityTypeBuilder<ProductComponent> entity)
    {
        entity.ToTable("product_components");
        entity.HasKey(pc => pc.Id);
        entity.Property(pc=>pc.Id).ValueGeneratedNever();

        entity.Property(pc => pc.KitProductId);
        entity.Property(pc => pc.ComponentProductId);
        entity.Property(pc => pc.Quantity).IsRequired();

        //relaciones
        entity.HasOne<Product>()
            .WithMany()
            .HasForeignKey(pc => pc.KitProductId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne<Product>()
            .WithMany()
            .HasForeignKey(pc => pc.ComponentProductId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
