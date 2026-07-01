using Microsoft.AspNetCore.Mvc;
using VendingMachine.Machines.Application;

namespace VendingMachine.Machines.Api;

[ApiController]
[Route("Machines")]
public class MachinesPostController(MachineService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateMachine([FromBody] CreateMachineRequest request)
    {
        var created = await service.CreateNewMachine(request);
        return Ok(created);
    }
}
