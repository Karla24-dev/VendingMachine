using Microsoft.EntityFrameworkCore;

using VendingMachine.Inventories.Domain;
using VendingMachine.Machines.Domain;
using VendingMachine.Products.Domain;

namespace VendingMachine.Service.Shared;

public class VendingDbContext(DbContextOptions<VendingDbContext> options) : DbContext(options)
{
    // cada dnset es una tabla
    // Aqui debes agregar una dbset or cada entidad q hagas
    public DbSet<Machine> Machines => Set<Machine>(); 
    public DbSet<Product> Products => Set<Product>(); 
    public DbSet<ProductComponent> ProductComponents => Set<ProductComponent>(); 
    public DbSet<Inventory> Inventories => Set<Inventory>(); 
    public DbSet<InventoryProduct> InventoryProducts => Set<InventoryProduct>(); 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

}
