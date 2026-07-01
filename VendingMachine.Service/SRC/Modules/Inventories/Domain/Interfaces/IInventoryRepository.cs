namespace VendingMachine.Inventories.Domain;

public interface IInventoryRepository
{
    Task<Inventory?> FindInventoryById(Guid inventoryId);
    Task<Inventory> CreateInventory(Inventory inventory);
    Task DeleteInventory(Guid inventoryId);
    Task<IEnumerable<Inventory>> ShowInventories();
    Task<Inventory> PatchInventoryById(Guid inventoryId, Inventory inventory);
}
