
using VendingMachine.Service.Service.Machines;

namespace VendingMachine.Service.Domain.Machines;

public class Machine
{
    public string Name {get;set;}
    public string Status {get;set;} = MachineStatus.Active.ToString();
    public string ImageUrl{get;set;}
    public string Address{get;set;}
    public int Id{get;set;}
    public int NumberOfRows{get;set;}
    public int NumberOfColumns{get;set;}
    public int MaxCapacity{get;set;}
    public DateTime InstallationDate{get;set;}    
    public Machine(
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
        Name = name;
        Status = status;
        ImageUrl = imageUrl;
        Address = address;
        NumberOfRows = nRows;
        NumberOfColumns = nColumns;
        MaxCapacity = capacity;
        InstallationDate = installationDate;

    }

}
