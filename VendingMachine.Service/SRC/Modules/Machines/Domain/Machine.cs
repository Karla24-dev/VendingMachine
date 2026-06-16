using VendingMachine.Service.Service.Machines;

namespace VendingMachine.Service.Domain.Machines;

public class Machine(
    string name,
    string status,
    string imageUrl,
    string address,
    int numberOfRows,
    int numberOfColumns,
    int maxCapacity,
    DateTime installationDate
    )
{
    public string Name { get; set; } = name;
    public string Status { get; set; } = status;
    public string ImageUrl { get; set; } = imageUrl;
    public string Address { get; set; } = address;
    public int Id { get; set; }
    public int NumberOfRows { get; set; } = numberOfRows;
    public int NumberOfColumns { get; set; } = numberOfColumns;
    public int MaxCapacity { get; set; } = maxCapacity;
    public DateTime InstallationDate { get; set; } = installationDate;
}
