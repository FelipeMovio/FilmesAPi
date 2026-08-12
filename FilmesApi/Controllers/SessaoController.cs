using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;

    public SessaoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarSessao([FromBody] CreateSessaoDto dto)
    {
        Sessao sessao = _mapper.Map<Sessao>(dto);
        _context.Sessoes.Add(sessao);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperarSessoesPorId),
    new { id = sessao.Id },
    dto);
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> RecuperarSessoes([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadSessaoDto>>
            (_context.Cinemas.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarSessoesPorId(int id)
    {
        Sessao sessao = _context.Sessoes.FirstOrDefault(c => c.Id == id);
        if (sessao != null)
        {
            ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(sessaoDto);
        }
        return NotFound();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaSessao(int id)
    {
       Sessao sessao = _context.Sessoes.FirstOrDefault(c => c.Id == id);
        if (sessao == null)
        {
            return NotFound();
        }
        _context.Remove(sessao);
        _context.SaveChanges();

        return NoContent();
    }
}
