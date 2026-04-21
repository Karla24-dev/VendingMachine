using System;

namespace VendingMachine.Service.Shared.db.Service;

using VendingMachine.Service.Domain.Machines;
using VendingMachine.Service.Modules.Machines.Application.Interfaces;

public class GoogleSheetsMachineRepository : IMachineRepository
{
    private readonly GoogleSheetsService _sheetsService;
    private const string SHEET_NAME = "Machines";

    public GoogleSheetsMachineRepository(GoogleSheetsService sheetsService)
    {
        _sheetsService = sheetsService;
    }

    // ========================================
    // IMPLEMENTACIÓN DE LOS MÉTODOS
    // ========================================

    public async Task<Machine> CreateNewMachine(Machine machine)
    {
        // 1. Asignar ID (obtener el siguiente disponible)
        var allMachines = await ShowMachines();
        machine.Id = allMachines.Any() ? allMachines.Max(m => m.Id) + 1 : 1;

        // 2. Crear fila para Google Sheets (según tu modelo: Id, Name, Status, n_Rows, n_Column, ImageUrl, InstallationDate)
        var row = new List<object>
        {
            machine.Id,
            machine.Name,
            machine.Status,
            machine.NumberOfRows,
            machine.NumberOfColumns,
            machine.ImageUrl ?? "",
            machine.InstallationDate.ToString("yyyy-MM-dd")
        };

        // 3. Agregar a Google Sheets
        await _sheetsService.AppendSheetAsync(SHEET_NAME, new List<IList<object>> { row });
        
        return machine;
    }

    public async Task<IEnumerable<Machine>> ShowMachines()
    {
        // Leer desde la fila 2 hasta la columna G (A2:G)
        var values = await _sheetsService.ReadSheetAsync(SHEET_NAME, "A2:G");

        if (values == null || values.Count == 0)
            return new List<Machine>();

        var machines = new List<Machine>();

        foreach (var row in values)
        {
            // Verificar que la fila tenga al menos 7 columnas
            if (row.Count < 7)
                continue;

            var machine = new Machine(
                name: row[1].ToString()!,
                status: row[2].ToString()!,
                imageUrl: row[5].ToString()!,
                address: "", // Tu modelo actual no tiene Address, lo dejamos vacío
                nRows: int.Parse(row[3].ToString()!),
                nColumns: int.Parse(row[4].ToString()!),
                capacity: int.Parse(row[3].ToString()!) * int.Parse(row[4].ToString()!), // Calculado
                installationDate: DateTime.Parse(row[6].ToString()!)
            );

            machine.Id = int.Parse(row[0].ToString()!);
            machines.Add(machine);
        }

        return machines;
    }

    public async Task<Machine?> FindeMachineById(int id)
    {
        var machines = await ShowMachines();
        return machines.FirstOrDefault(m => m.Id == id);
    }

    public async Task<IEnumerable<Machine>> FideMachinesByIds(List<int> ids)
    {
        var machines = await ShowMachines();
        return machines.Where(m => ids.Contains(m.Id));
    }

    public async Task<bool> DeletMachineById(int id)
    {
        var machine = await FindeMachineById(id);
        if (machine == null)
            return false;

        // Marcar como inactiva (soft delete)
        machine.Status = "Inactive";
        await PathMachineById(id, machine);
        
        return true;
    }

    public async Task<Machine> PathMachineById(int id, Machine machine)
    {
        var allMachines = await ShowMachines();
        var machinesList = allMachines.ToList();
        var index = machinesList.FindIndex(m => m.Id == id);

        if (index == -1)
            throw new Exception($"Machine with ID {id} not found");

        // Crear fila actualizada
        var row = new List<object>
        {
            machine.Id,
            machine.Name,
            machine.Status,
            machine.NumberOfRows,
            machine.NumberOfColumns,
            machine.ImageUrl ?? "",
            machine.InstallationDate.ToString("yyyy-MM-dd")
        };

        // Actualizar en Google Sheets (fila index+2 porque fila 1 es header)
        var range = $"A{index + 2}:G{index + 2}";
        await _sheetsService.UpdateSheetAsync(SHEET_NAME, range, new List<IList<object>> { row });

        return machine;
    }

    public async Task<string> GetStatusByMachineId(int id)
    {
        var machine = await FindeMachineById(id);
        return machine?.Status ?? "";
    }
}
