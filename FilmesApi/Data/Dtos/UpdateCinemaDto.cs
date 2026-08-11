using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "Campo Nome obrigatorio")]
    public string Nome { get; set; }
}
