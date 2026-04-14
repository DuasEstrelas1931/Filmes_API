using FilmesApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi1.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
    {
    }

    public DbSet<Filme> Filmes { get; set; }
}
