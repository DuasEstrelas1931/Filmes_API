using FilmesApi1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi1.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    // POST /filme - Adicionar um novo filme
    [HttpPost]
    public IActionResult AdcionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);

        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Genero);
        Console.WriteLine(filme.Duracao);

        return CreatedAtAction(nameof(ObterFilmesId), new { id = filme.Id }, filme);
    }
    // GET /filme - Obter a lista de filmes
    [HttpGet]
    public IActionResult ObterFilmes()
    {
        return Ok(filmes);
    }
    // GET /filme/{id} - Obter um filme por ID
    [HttpGet("{id}")]
    public IActionResult ObterFilmesId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        return Ok(filme);
    }
    // PUT /filme/{id} - Atualizar um filme existente
    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] Filme filmeAtualizado)
    {
        var filme = filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null)
        {
            return NotFound();
        }

        filme.Titulo = filmeAtualizado.Titulo;
        filme.Genero = filmeAtualizado.Genero;
        filme.Duracao = filmeAtualizado.Duracao;

        return NoContent();
    }
    // DELETE /filme/{id} - Excluir um filme por ID
    [HttpDelete("{id}")]
    public IActionResult ExcluirFilme(int id)
    {
        var filme = filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null)
        {
            return NotFound(id);
        }

        filmes.Remove(filme);

        return NoContent();
    }
}