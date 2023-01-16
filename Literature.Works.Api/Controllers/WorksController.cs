using Literature.Works.Api.Application.Commands.Works;
using Literature.Works.Api.Application.Queries.Works;
using Literature.Works.Models.Works;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Literature.Works.Api.Controllers;

[ApiController]
[Route("api/works")]
public class WorksController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(WorkModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetWorksListRequest request) 
        => Ok(await _mediator.Send(request));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddWorkRequest request)
        => Ok(await _mediator.Send(request));
}