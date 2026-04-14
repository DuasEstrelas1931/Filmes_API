using System.ComponentModel.DataAnnotations;

namespace FilmesApi1.Models;

public class Filme
{
    [Key]
    [Required(ErrorMessage = "O ID do filme é obrigatório.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "O título do filme é obrigatório.")]
    public required string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório.")]
    [StringLength(100, ErrorMessage = "O gênero do filme não pode exceder 100 caracteres.")]
    public required string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatória.")]
    [Range(70, 600, ErrorMessage = "A duração do filme deve estar entre 70 e 600 minutos.")]
    public int Duracao { get; set; }
}
