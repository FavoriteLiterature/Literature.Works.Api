using Literature.Works.Api.Application.Commands.Genres;
using Literature.Works.Api.Application.Queries.Genres;
using Literature.Works.Models.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Literature.Works.Api.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GenreModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromQuery] GetGenresListRequest request) 
        => Ok(await _mediator.Send(request));

    [HttpPost]
    [ProducesResponseType(typeof(GenreModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddGenreRequest request)
        => Ok(await _mediator.Send(request));
}