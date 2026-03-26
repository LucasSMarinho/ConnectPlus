using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.WebAPI.DTO;

public class ContatoDTO
{
    [Required(ErrorMessage = "O Nome do contato é obrigatorio")]
    public string? Nome {  get; set; }

    [Required(ErrorMessage = "A imagem do contato é obrigatoria")]
    public IFormFile? Imagem { get; set; }

    [Required(ErrorMessage = "A forma de contato é obrigatoria")]
    public string? FormaContato { get; set; }

    [Required(ErrorMessage = "O tipo de contato é obrigatorio")]
    public Guid IdTipoContato {  get; set; }

}