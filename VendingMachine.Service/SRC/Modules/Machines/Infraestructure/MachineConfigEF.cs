namespace VendingMachine.Service.Shared;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Service.Domain.Machines;

public class MachineConfigEF : IEntityTypeConfiguration<Machine>
{
    public void Configure(EntityTypeBuilder<Machine> entity)
    {
        entity.ToTable("machines");
        entity.HasKey(m => m.Id);
        entity.Property(m => m.Id).ValueGeneratedOnAdd();
    }
}