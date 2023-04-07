using Aula01.Models;

namespace Aula01.Repositories.Interfaces;

public interface IMovieRepository
{
    void Adicionar(Movie movie);
    List<Movie> ObterLista();
    Movie? ObterPorId(int id);
    void Atualizar(Movie movie);
    void Excluir(int id);
}