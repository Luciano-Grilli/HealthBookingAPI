using HealthBookingAPI.Application.CQRS.Categories.Commands.CreateCategories;
using HealthBookingAPI.Application.CQRS.Categories.Commands.DeleteCategories;
using HealthBookingAPI.Application.CQRS.Categories.Commands.UpdateCategories;
using HealthBookingAPI.Application.CQRS.Categories.Queries.GetCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthBookingAPI.Web.Controller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoriesController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetCategoriesQuery>> GetCategoriesLists()
    {
        var vm = await _sender.Send(new GetCategoriesQuery());
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<CreateCategoriesCommand>> CreateCategories([FromBody] CreateCategoriesCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateCategoriesCommand>> UpdateCategories([FromBody] UpdateCategoriesCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }

    [HttpDelete]
    public async Task<ActionResult<DeleteCategoriesCommand>> DeleteCategories([FromBody] DeleteCategoriesCommand command)
    {
        var vm = await _sender.Send(command);
        return Ok(vm);
    }
}
