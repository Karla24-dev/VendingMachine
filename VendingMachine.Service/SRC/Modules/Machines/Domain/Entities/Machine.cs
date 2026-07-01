
namespace VendingMachine.Machines.Domain;

public class Machine(
    string name,
    string status,
    string imageUrl,
    string address,
    int numberOfRows,
    int numberOfColumns,

    DateTime installationDate
    )
{
    public string Name { get; set; } = name;
    public string Status { get; set; } = status;
    public string ImageUrl { get; set; } = imageUrl;
    public string Address { get; set; } = address;
    public Guid Id { get; set; } = Guid.NewGuid();
    public int NumberOfRows { get; set; } = numberOfRows;
    public int NumberOfColumns { get; set; } = numberOfColumns;
    public DateTime InstallationDate { get; set; } = installationDate;
}
