using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{

    [Required(ErrorMessage = "O titulo do filme es obrigatorio")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O genero do filme es obrigatorio ")]
    [StringLength(100, ErrorMessage = "O tamanho do genero nao pode ser maior que 100")]
    public string Genero { get; set; } = string.Empty;

    [Required(ErrorMessage = "")]
    [Range(70, 600, ErrorMessage = "A duracao deve ter entre 70 a 600 minutos")]
    public int Duracao { get; set; }



}
}
