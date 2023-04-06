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

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id.Equals(id));

        if (movie == null)
            return NotFound();

        return Ok(movie);
    }

    [HttpPost]
    public IActionResult Create([FromBody] FilmeCriacaoDto movieDto)
    {
        var movie = new Movie();

        if (string.IsNullOrEmpty(movieDto.Titulo))
            return BadRequest("Título inválido");
        else
            movie.Titulo = movieDto.Titulo;
       
        if (string.IsNullOrEmpty(movieDto.Genero))
           return BadRequest("Gênero inválido");
        else
            movie.Genero = movieDto.Genero;

        movie.DataDeLancamento = movieDto.DataDeLancamento;

        _context.Movies.Add(movie);
        _context.SaveChanges();

        var movieDtoSaida = new FilmeCriacaoSaidaDto();

        movieDtoSaida.Id = movie.Id;
        movieDtoSaida.Titulo = movieDto.Titulo;
        movieDtoSaida.Genero = movieDto.Genero;
        movieDtoSaida.DataDeLancamento = movieDto.DataDeLancamento;

        return CreatedAtAction(nameof(MovieController.Get), new { id = movie.Id }, movieDtoSaida);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Delete(int id, [FromBody] FilmeAlteracaoDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(x => x.Id.Equals(id));

        if (movie == null)
            return NotFound();

        movie.Titulo = movieDto.Titulo;
        movie.Genero = movieDto.Genero;

        _context.Movies.Update(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(MovieController.Get), new { id = movie.Id }, movie);
    }

}


public class FilmeCriacaoDto
{

    public string Titulo { get; set; }
    public string Genero { get; set; }
    public DateTime DataDeLancamento { get; set; }
}

public class FilmeCriacaoSaidaDto
{

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public DateTime DataDeLancamento { get; set; }
}

public class FilmeAlteracaoDto
{

    public string Titulo { get; set; }
    public string Genero { get; set; }

    public string ObterFrase()
    {

        return $"Filme {Titulo} de {Genero}";
    }
}
