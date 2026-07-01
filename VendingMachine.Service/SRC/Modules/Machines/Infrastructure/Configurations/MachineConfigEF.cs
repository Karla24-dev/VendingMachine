namespace VendingMachine.Machines.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Machines.Domain;

public class MachineConfigEF : IEntityTypeConfiguration<Machine>
{
    public void Configure(EntityTypeBuilder<Machine> entity)
    {
        entity.ToTable("machines");
        entity.HasKey(m => m.Id);
        entity.Property(m => m.Id).ValueGeneratedNever();
        // Campos obligatorios (IsRequired = no pueden quedar vacíos)
        entity.Property(m => m.Name).IsRequired();
        entity.Property(m => m.Status).IsRequired();
        entity.Property(m => m.Address).IsRequired();
        entity.Property(m => m.NumberOfRows).IsRequired();
        entity.Property(m => m.NumberOfColumns).IsRequired();
        entity.Property(m => m.InstallationDate).IsRequired();

        // Imagen opcional (puede quedar vacía)
        entity.Property(m => m.ImageUrl).IsRequired(false);
    }
}
