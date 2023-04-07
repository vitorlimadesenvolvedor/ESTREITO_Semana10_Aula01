using System.ComponentModel.DataAnnotations.Schema;

namespace Aula01.Models;


public class Movie {

    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public DateTime DataDeLancamento { get; set; }
}