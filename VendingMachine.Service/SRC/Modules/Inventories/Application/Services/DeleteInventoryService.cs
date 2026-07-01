using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;

public class DeleteInventoryService(IInventoryRepository repository)
{
    public async Task DeleteInventory(Guid inventoryId)
    {
        await repository.DeleteInventory(inventoryId);
    }
}
