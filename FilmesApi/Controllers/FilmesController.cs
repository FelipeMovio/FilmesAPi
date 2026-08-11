using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmesController : Controller
{

    private FilmeContext context;
    private IMapper mapper;

    public FilmesController(FilmeContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {
        Filme filme = mapper.Map<Filme>(filmeDto);

        context.Filmes.Add(filme);
        context.SaveChanges();
        return CreatedAtAction(nameof(VerPorIdFilmes),
            new {id = filme.Id},
            filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> VerFilmes([FromQuery]int skip = 0,
        [FromQuery] int take = 50)
    {
        return mapper.Map<List<ReadFilmeDto>>
            (context.Filmes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult VerPorIdFilmes(int id)
    {
        var filme = context.Filmes.FirstOrDefault(f => f.Id == id);

        if (filme == null)
        {
            return NotFound();

        }

        var filmeDto = mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, 
        [FromBody] UpdateFilmeDto UpdatefilmeDto)
    {
        var filme = context.Filmes.FirstOrDefault(
            f => f.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        mapper.Map(UpdatefilmeDto, filme);
        context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]

    public IActionResult AtualizarFilmeParcial(int id,
        [FromBody] UpdateFilmeParcialDto dto)
    {
        var filme = context.Filmes.FirstOrDefault(
            f => f.Id == id);
        if (filme == null)
        {
            return NotFound();
        }

        mapper.Map(dto, filme);

        context.SaveChanges();

        return NoContent();
    }


    [HttpDelete("{id}")]

    public IActionResult DeletaFilme(int id)
    {
        var filme = context.Filmes.FirstOrDefault(
            f => f.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        context.Remove(filme);
        context.SaveChanges();

        return NoContent();
    }
}