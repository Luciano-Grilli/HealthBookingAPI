using HealthBookingAPI.Application.CQRS.Appointments.Commands.CreateAppointments;
using HealthBookingAPI.Application.CQRS.Appointments.Commands.DeleteAppointments;
using HealthBookingAPI.Application.CQRS.Appointments.Commands.UpdateAppointments;
using HealthBookingAPI.Application.CQRS.Appointments.Queries.GetAppointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthBookingAPI.Web.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AppointmentsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetAppointmentsQuery>> GetAppointmentLists()
    {
        var vm = await _sender.Send(new GetAppointmentsQuery());
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAppointmentsCommand>> CreateAppointment([FromBody] CreateAppointmentsCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateAppointmentsCommand>> UpdateAppointment([FromBody] UpdateAppointmentsCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteAppointmentsCommand>> DeleteAppointment([FromBody] DeleteAppointmentsCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }
}
