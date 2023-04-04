using Aula01.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula01.Context;

public class MovieContext : DbContext {
  
  public MovieContext(DbContextOptions<MovieContext> options) : base (options)
  {
    
  }
  
  public DbSet<Movie> Movies { get; set; }
}
