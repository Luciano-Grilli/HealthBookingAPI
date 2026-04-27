using HealthBookingAPI.Application.CQRS.Professionals.Commands.CreateProfessionals;
using HealthBookingAPI.Application.CQRS.Professionals.Commands.DeleteProfessionals;
using HealthBookingAPI.Application.CQRS.Professionals.Commands.UpdateProfessionals;
using HealthBookingAPI.Application.CQRS.Professionals.Queries.GetProfessionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthBookingAPI.Web.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProfessionalsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetProfessionalsQuery>> GetProfessionalsLists()
    {
        var vm = await _sender.Send(new GetProfessionalsQuery());
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<CreateProfessionalsCommand>> CreateProfessionals([FromBody] CreateProfessionalsCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateProfessionalsCommand>> UpdateProfessionals([FromBody] UpdateProfessionalsCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteProfessionalsCommand>> DeleteProfessionals([FromBody] DeleteProfessionalsCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }
}
