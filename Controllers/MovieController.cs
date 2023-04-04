using Aula01.Context;
using Aula01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var movies = _context.Movies.ToList();

        return Ok(movies);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        
        return CreatedAtAction(nameof(MovieController.Get), new { id = movie.Id }, movie);
    }

}