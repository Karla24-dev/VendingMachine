namespace VendingMachine.Inventories.Application;

public class InventoryService(IInventoryRepository repository)
{
    public async Task<Inventory> CreateInventory(Inventory inventory)
    {
        ValidateInventory(inventory);
        return await repository.CreateInventory(inventory);
    }

    public async Task<IEnumerable<Inventory>> ShowInventories()
    {
        return await repository.ShowInventories();
    }

    public async Task<Inventory?> FindInventoryById(Guid inventoryId)
    {
        return await repository.FindInventoryById(inventoryId);
    }

    public async Task DeleteInventory(Guid inventoryId)
    {
        await repository.DeleteInventory(inventoryId);
    }

    public async Task<Inventory> PatchInventoryById(Guid inventoryId, Inventory inventory)
    {
        ValidateInventory(inventory);
        return await repository.PatchInventoryById(inventoryId, inventory);
    }

    private void ValidateInventory(Inventory inventory)
    {
        if (string.IsNullOrWhiteSpace(inventory.Name))
            throw new ArgumentException("El nombre del inventario es obligatorio.");

        if (inventory.Type == InventoryType.Machine && inventory.MachineId is null)
            throw new ArgumentException("Un inventario de tipo Machine debe tener un MachineId.");

        if (inventory.Type == InventoryType.WareHouse && inventory.MachineId is not null)
            throw new ArgumentException("Un inventario de tipo WareHouse no puede tener un MachineId.");
    }
}
