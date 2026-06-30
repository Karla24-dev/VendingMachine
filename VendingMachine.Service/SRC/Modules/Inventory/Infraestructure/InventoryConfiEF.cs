using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Inventories.Domain;
using VendingMachine.Service.Domain.Machines;

namespace VendingMachine.Inventories.Infraestructure;

public class InventoryConfiEF : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> entity)
    {
        entity.ToTable("inventories", t =>
            t.HasCheckConstraint(
            "CK_Inventory_MachineType",
            "(\"Type\" = 'Machine' AND \"MachineId\" IS NOT NULL) OR (\"Type\" = 'WareHouse' AND \"MachineId\" IS NULL)"));
        
        entity.HasKey(i => i.Id);
        entity.Property(i => i.Id).ValueGeneratedOnAdd();

        // Campos obligatorios
        entity.Property(i => i.Type)
            .HasConversion<string>()
            .IsRequired();
        entity.Property(i => i.Name).IsRequired().HasMaxLength(100);

        // Campos unicos
        entity.HasIndex(i => i.MachineId).IsUnique();

        // Relaciones
        entity.HasOne<Machine>()
            .WithOne()
            .HasForeignKey<Inventory>(i => i.MachineId)
            .IsRequired(false);
    }

}
