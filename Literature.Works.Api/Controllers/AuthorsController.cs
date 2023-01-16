using Literature.Works.Api.Application.Queries.Authors;
using Literature.Works.Models.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Literature.Works.Api.Controllers;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(AuthorModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetAuthorsListRequest request)
        => Ok(await _mediator.Send(request));
}