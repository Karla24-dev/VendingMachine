using VendingMachine.Inventories.Domain;

namespace VendingMachine.Inventories.Application;

public class UpDateInventoryService(IInventoryRepository repository):IUpDateInventoryService
{
    public async Task<Inventory> PatchInventoryById(Guid inventoryId, Inventory inventory)
    {
        InventoryValidator.Validate(inventory);
        return await repository.PatchInventoryById(inventoryId, inventory);
    }
}
internal static class InventoryValidator
{
    public static void Validate(Inventory inventory)
    {
        if (string.IsNullOrWhiteSpace(inventory.Name))
            throw new ArgumentException("El nombre del inventario es obligatorio.");

        if (inventory.Type == InventoryType.Machine && inventory.MachineId is null)
            throw new ArgumentException("Un inventario de tipo Machine debe tener un MachineId.");

        if (inventory.Type == InventoryType.WareHouse && inventory.MachineId is not null)
            throw new ArgumentException("Un inventario de tipo WareHouse no puede tener un MachineId.");
    }
}
