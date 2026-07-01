using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;

public interface ICreateInventoryService
{
    Task<Inventory> CreateInventory(Inventory inventory);
}