using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;

public interface IUpDateInventoryService
{
    Task<Inventory> PatchInventoryById(Guid inventoryId, Inventory inventory);
}