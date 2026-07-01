using Microsoft.EntityFrameworkCore;
using VendingMachine.Machines.Domain;
using VendingMachine.Shared.Infrastructure;

namespace VendingMachine.Machines.Infrastructure;

public class EfMachineRepository(VendingDbContext db) : IMachineRepository
{
    public async Task<Machine> CreateNewMachine(Machine machine)
    {
        db.Machines.Add(machine);
        await db.SaveChangesAsync();
        return machine;
    }

    public async Task<IEnumerable<Machine>> ShowMachines()
    {
        return await db.Machines.ToListAsync();
    }

    public async Task<Machine?> FindeMachineById(Guid id)
    {
        return await db.Machines.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Machine>> FideMachinesByIds(List<Guid> ids)
    {
        return await db.Machines
            .Where(m => ids.Contains(m.Id))
            .ToListAsync();
    }

    public async Task<bool> DeletMachineById(Guid id)
    {
        var machine = await FindeMachineById(id);
        if (machine == null)
            return false;

        machine.Status = "Inactive";
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<Machine> PathMachineById(Guid id, Machine machine)
    {
        var existing = await db.Machines.FirstOrDefaultAsync(m => m.Id == id);
        if (existing == null)
            throw new Exception($"Machine with ID {id} not found");

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

    public async Task<string> GetStatusByMachineId(Guid id)
    {
        var machine = await FindeMachineById(id);
        return machine?.Status ?? "";
    }
}
