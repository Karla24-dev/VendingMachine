namespace VendingMachine.Inventories.Domain;

public class Inventory(
    string name,
    Guid? machineId = null
    )
{
    public Guid Id {get;set;}
    public string Name { get; set; } = name;
    public Guid? MachineId { get; set; }= machineId;
}
