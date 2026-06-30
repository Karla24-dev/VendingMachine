namespace VendingMachine.Inventories.Api;

using VendingMachine.Inventories.Domain;

public class CreateInventoryRequest
{
    public string Name { get; set; } = string.Empty;
    public InventoryType Type { get; set; }
    public Guid? MachineId { get; set; }
}
