using Literature.Works.Api.Entities;
using Literature.Works.Api.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Literature.Works.Api.Controllers;

[ApiController]
[Route("api/genres")]
public class GenresController : ControllerBase
{
    private readonly IRepository _repository;

    public GenresController(IRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var genres = _repository.Genres.AsQueryable();
        
        var entities = await genres
            .ToArrayAsync(cancellationToken);

        return Ok(entities);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Genre genre, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(genre, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}