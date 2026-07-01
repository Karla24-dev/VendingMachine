using VendingMachine.Machines.Api;
using VendingMachine.Machines.Domain;

namespace VendingMachine.Machines.Application;

public interface ICreateMachineService
{
    Task<Machine> CreateNewMachine(CreateMachineRequest request);

}
