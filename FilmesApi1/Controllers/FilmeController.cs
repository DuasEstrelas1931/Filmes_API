using AutoMapper;
using FilmesApi1.Data;
using FilmesApi1.Data.Dtos;
using FilmesApi1.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilmesApi1.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;   
    }


    // POST /filme - Adicionar um novo filme
    [HttpPost]
    public IActionResult AdcionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(nameof(ObterFilmesId), new { id = filme.Id }, filme);
    }
    // GET /filme - Obter a lista de filmes
    [HttpGet]
    public IActionResult ObterFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10 )
    {
        return Ok(_context.Filmes.Skip(skip).Take(take));
    }
    // GET /filme/{id} - Obter um filme por ID
    [HttpGet("{id}")]
    public IActionResult ObterFilmesId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
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
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null)
        {
            return NotFound();
        }

        filme.Titulo = filmeAtualizado.Titulo;
        filme.Genero = filmeAtualizado.Genero;
        filme.Duracao = filmeAtualizado.Duracao;

        _context.Update(filme);
        _context.SaveChanges();

        return NoContent();
    }
    // DELETE /filme/{id} - Excluir um filme por ID
    [HttpDelete("{id}")]
    public IActionResult ExcluirFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null)
        {
            return NotFound(id);
        }

        _context.Filmes.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}