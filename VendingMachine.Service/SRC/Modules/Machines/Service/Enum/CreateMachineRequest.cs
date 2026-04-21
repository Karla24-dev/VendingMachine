using VendingMachine.Service.Service.Machines;

namespace VendingMachine.Service.Machines.Service;

public class CreateMachineRequest
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Status{get;set;}=MachineStatus.Active.ToString();
    public int NumberOfRows { get; set; }
    public int NumberOfColumns { get; set; }
    public DateTime InstallationDate { get; set; }
    public string? ImageUrl { get; set; }
}
