using Microsoft.EntityFrameworkCore;
using VendingMachine.Inventories.Domain;
using VendingMachine.Service.Shared;

namespace VendingMachine.Inventories.Infraestructure;

public class EfInventoryRepository(VendingDbContext db) : IInventoryRepository
{
    public async Task<Inventory> CreateInventory(Inventory inventory)
    {
        db.Inventories.Add(inventory);
        await db.SaveChangesAsync();
        return inventory;
    }

    public async Task<IEnumerable<Inventory>> ShowInventories()
    {
        return await db.Inventories.ToListAsync();
    }

    public async Task<Inventory?> FindInventoryById(Guid inventoryId)
    {
        return await db.Inventories.FirstOrDefaultAsync(i => i.Id == inventoryId);
    }

    public async Task DeleteInventory(Guid inventoryId)
    {
        var inventory = await FindInventoryById(inventoryId);
        if (inventory == null)
            return;

        db.Inventories.Remove(inventory);
        await db.SaveChangesAsync();
    }

    public async Task<Inventory> PatchInventoryById(Guid inventoryId, Inventory inventory)
    {
        var existing = await db.Inventories.FirstOrDefaultAsync(i => i.Id == inventoryId);
        if (existing == null)
            throw new Exception($"Inventory with ID {inventoryId} not found");

        existing.Name = inventory.Name;
        existing.Type = inventory.Type;
        existing.MachineId = inventory.MachineId;

        await db.SaveChangesAsync();
        return existing;
    }
}
