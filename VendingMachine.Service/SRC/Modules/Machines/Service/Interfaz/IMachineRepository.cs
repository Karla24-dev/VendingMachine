namespace VendingMachine.Service.Modules.Machines.Application.Interfaces;

using VendingMachine.Service.Domain.Machines;

public interface IMachineRepository
{
    Task<IEnumerable<Machine>> ShowMachines();
    Task<Machine?> FindeMachineById(Guid id);
    Task<IEnumerable<Machine>> FideMachinesByIds(List<Guid> ids);
    Task<Machine> CreateNewMachine(Machine machine);
    Task<bool> DeletMachineById(Guid id);
    Task<Machine> PathMachineById(Guid id, Machine machine);
    Task<string> GetStatusByMachineId(Guid id);
}