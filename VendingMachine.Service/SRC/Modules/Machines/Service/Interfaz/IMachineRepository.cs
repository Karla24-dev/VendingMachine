namespace VendingMachine.Service.Modules.Machines.Application.Interfaces;

using VendingMachine.Service.Domain.Machines;

public interface IMachineRepository
{
    Task<IEnumerable<Machine>> ShowMachines();
    Task<Machine?> FindeMachineById(int id);
    Task<IEnumerable<Machine>> FideMachinesByIds(List<int> ids);
    Task<Machine> CreateNewMachine(Machine machine);
    Task<bool> DeletMachineById(int id);
    Task<Machine> PathMachineById(int id, Machine machine);
    Task<string> GetStatusByMachineId(int id);
}