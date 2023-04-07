using Aula01.Context;
using Aula01.Models;
using Aula01.Repositories.Interfaces;

namespace Aula01.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieContext _context;

    public MovieRepository(MovieContext context)
    {
        _context = context;
    }
    
    public void Adicionar(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public List<Movie> ObterLista()
    {
        return _context.Movies.ToList();
    }

    public Movie? ObterPorId(int id)
    {
       return _context.Movies.FirstOrDefault(x => x.Id.Equals(id));
    }

    public void Atualizar(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var movie = ObterPorId(id);
        _context.Movies.Remove(movie);
        _context.SaveChanges();

    }
    
}