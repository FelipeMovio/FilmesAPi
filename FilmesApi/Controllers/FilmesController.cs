using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmeController : Controller
{

    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
    }
}