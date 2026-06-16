using Microsoft.EntityFrameworkCore;
using VendingMachine.Service.Domain.Machines;

namespace VendingMachine.Service.Shared;

public class VendingDbContext(DbContextOptions<VendingDbContext> options) : DbContext(options)
{
    // cada dnset es una tabla
    public DbSet<Machine> Machines => Set<Machine>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

}
