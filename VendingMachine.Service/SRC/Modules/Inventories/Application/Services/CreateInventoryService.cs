using VendingMachine.Inventories.Domain;
using VendingMachine.Inventories.Application;

namespace VendingMachine.Inventories.Application;

public class CreateInventoryService(IInventoryRepository repository):ICreateInventoryService
{
    public async Task<Inventory> CreateInventory(Inventory inventory)
    {
        InventoryValidator.Validate(inventory);
        return await repository.CreateInventory(inventory);
    }
}