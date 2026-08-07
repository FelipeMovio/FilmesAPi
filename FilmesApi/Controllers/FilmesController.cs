using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmesController : Controller
{

    private FilmeContext context;

    public FilmesController(FilmeContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {

        context.Filmes.Add(filme);
        context.SaveChanges();
        return CreatedAtAction(nameof(VerPorIdFilmes),
            new {id = filme.Id},
            filme);
    }

    [HttpGet]
    public List<Filme> VerFilmes([FromQuery]int skip = 0,
        [FromQuery] int take = 50)
    {
        return context.Filmes.Skip(skip).Take(take).ToList();
    }

    [HttpGet("{id}")]
    public IActionResult VerPorIdFilmes(int id)
    {
        var filme = context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null)
        {
            return NotFound();

        }
        return Ok(filme);
    }
}