using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : Controller
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperarCinemasPorId),
    new { id = cinema.Id },
    cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperarCinemas([FromQuery] int? enderecoId = null)
    {
        if (enderecoId == null)
        {
            return _mapper.Map<List<ReadCinemaDto>>
                (_context.Cinemas.ToList());
        }
        //return _mapper.Map<List<ReadCinemaDto>>
        //        (_context.Cinemas
        //        .Where(cinema => cinema.EnderecoId == enderecoId)
        //        .ToList());

        //Fazem a mesma coisa so que um por consulta LINQ e outro por consultaSql

        return _mapper.Map<List<ReadCinemaDto>>
                (_context.Cinemas.FromSqlRaw
            ($"SELECT Id,Nome,EnderecoId FROM cinemas where cinemas.EnderecoId = {enderecoId}")
            .ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarCinemasPorId(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema != null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto >(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCinema(int id,
        [FromBody] UpdateCinemaDto cinemaDto )
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

        if (cinema == null)
        {
            return NotFound();
        }
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null)
        {
            return NotFound();
        }
        _context.Remove(cinema);
        _context.SaveChanges();

        return NoContent();
    }
}
