using Microsoft.AspNetCore.Mvc;
using VendingMachine.Machines.Application;

namespace VendingMachine.Machines.Api;

[ApiController]
[Route("Machines")]
public class CreateMachinesController(ICreateMachineService iService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateMachine([FromBody] CreateMachineRequest request)
    {
        var created = await iService.CreateNewMachine(request);
        return Ok(created);
    }
}
