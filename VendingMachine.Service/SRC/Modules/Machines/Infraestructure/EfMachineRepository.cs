namespace VendingMachine.Service.Shared.db.Service;

using Microsoft.EntityFrameworkCore;
using VendingMachine.Service.Domain.Machines;
using VendingMachine.Service.Modules.Machines.Application.Interfaces;

public class EfMachineRepository(VendingDbContext db) : IMachineRepository
{
    public async Task<Machine> CreateNewMachine(Machine machine)
    {
        db.Machines.Add(machine);          // marcar para insertar
        await db.SaveChangesAsync();        // ejecutar de verdad en Supabase
        return machine;                      // el Id ya viene lleno por la BD
    }

    public async Task<IEnumerable<Machine>> ShowMachines()
    {
        return await db.Machines.ToListAsync();
    }

    public async Task<Machine?> FindeMachineById(int id)
    {
        return await db.Machines.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Machine>> FideMachinesByIds(List<int> ids)
    {
        return await db.Machines
            .Where(m => ids.Contains(m.Id))
            .ToListAsync();
    }

    public async Task<bool> DeletMachineById(int id)
    {
        var machine = await FindeMachineById(id);
        if (machine == null)
            return false;

        // Soft delete: mismo comportamiento que tenías en Sheets
        machine.Status = "Inactive";
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<Machine> PathMachineById(int id, Machine machine)
    {
        var existing = await db.Machines.FirstOrDefaultAsync(m => m.Id == id);
        if (existing == null)
            throw new Exception($"Machine with ID {id} not found");

        // Copiamos los valores nuevos sobre la máquina existente
        existing.Name = machine.Name;
        existing.Status = machine.Status;
        existing.ImageUrl = machine.ImageUrl;
        existing.Address = machine.Address;
        existing.NumberOfRows = machine.NumberOfRows;
        existing.NumberOfColumns = machine.NumberOfColumns;
        existing.InstallationDate = machine.InstallationDate;

        await db.SaveChangesAsync();
        return existing;
    }

    public async Task<string> GetStatusByMachineId(int id)
    {
        var machine = await FindeMachineById(id);
        return machine?.Status ?? "";
    }
}
