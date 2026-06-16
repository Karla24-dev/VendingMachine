namespace VendingMachine.Service.Modules.Machines.Application.Services;

using VendingMachine.Service.Domain.Machines;
using VendingMachine.Service.Modules.Machines.Application.Interfaces;
using VendingMachine.Service.Machines.Service;


public class MachineService
{
    private readonly IMachineRepository _repository;

    public MachineService(IMachineRepository repository)
    {
        _repository = repository;
    }

    public async Task<Machine> CreateNewMachine(CreateMachineRequest request)
    {
        // Crear la máquina usando tu constructor
        var machine = new Machine(
            name: request.Name,
            status: request.Status ?? "Active",
            imageUrl: request.ImageUrl ?? "",
            address: request.Address,
            numberOfRows: request.NumberOfRows,
            numberOfColumns: request.NumberOfColumns,
            installationDate: request.InstallationDate
        );

        // Llamar al método de tu interfaz
        var created = await _repository.CreateNewMachine(machine);

        return created;
    }
}