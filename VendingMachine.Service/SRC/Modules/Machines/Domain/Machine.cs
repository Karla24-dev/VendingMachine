
using VendingMachine.Service.Service.Machines;

namespace VendingMachine.Service.Domain.Machines;

public class Machine(
    string name,
    string status,
    string imageUrl,
    string address,
    int nRows,
    int nColumns,
    int capacity,
    DateTime installationDate
    )
{
    public string Name { get; set; } = name;
    public string Status { get; set; } = status;
    public string ImageUrl { get; set; } = imageUrl;
    public string Address { get; set; } = address;
    public int Id{get;set;}
    public int NumberOfRows { get; set; } = nRows;
    public int NumberOfColumns { get; set; } = nColumns;
    public int MaxCapacity { get; set; } = capacity;
    public DateTime InstallationDate { get; set; } = installationDate;
}
