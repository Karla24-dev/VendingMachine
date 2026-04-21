using Microsoft.AspNetCore.Mvc;
using VendingMachine.Service.Machines.Service;
using VendingMachine.Service.Modules.Machines.Application.Services;

namespace VendingMachine.Service.SRC.Modules.Machines.Api;

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