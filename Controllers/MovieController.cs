using Aula01.Context;
using Aula01.Models;
using Aula01.Repositories.Interfaces;
using Aula01.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieRepository _movieRepository; 
    private readonly IMapper _mapper;
    
    public MovieController(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var movies = _movieRepository.ObterLista();
        return Ok(movies);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        var movie = _movieRepository.ObterPorId(id);

        if (movie == null)
            return NotFound();

        return Ok(movie);
    }

    [HttpPost]
    public IActionResult Create([FromBody] FilmeCriacaoDto dto)
    {
        if (ModelState.IsValid == false)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        var movie = _mapper.Map<Movie>(dto);

        _movieRepository.Adicionar(movie);

        var movieDtoSaida = _mapper.Map<FilmeCriacaoSaidaDto>(movie);

        return CreatedAtAction(nameof(MovieController.Get), new { id = movie.Id }, movieDtoSaida);
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update(int id, [FromBody] FilmeAlteracaoDto movieDto)
    {
        var movie = _movieRepository.ObterPorId(id);

        if (movie == null)
            return NotFound();

        movie.Titulo = movieDto.Titulo;
        movie.Genero = movieDto.Genero;
        
        return CreatedAtAction(nameof(MovieController.Get), new { id = movie.Id }, movie);
    }

}


public class FilmeCriacaoDto
{

    public string Titulo { get; set; }
    public string Genero { get; set; }
    public DateTime DataDeLancamento { get; set; }
    public DiretorDto Diretor { get; set; }
}

public class DiretorDto {
    public string Cpf { get; set; }

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
