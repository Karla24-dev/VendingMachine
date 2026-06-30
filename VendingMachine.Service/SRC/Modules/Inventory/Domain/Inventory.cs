namespace VendingMachine.Inventories.Domain;

public class Inventory(
    string name,
    InventoryType type,
    Guid? machineId = null
    )
{
    public Guid Id { get; set; }
    public string Name { get; set; } = name;
    public InventoryType Type { get; set; } = type;
    public Guid? MachineId { get; set; } = machineId;
}
