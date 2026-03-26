using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.WebAPI.DTO;

public class TipoContatoDTO
{
    [Required(ErrorMessage = "O titulo do tipo contato é obrigatoria")]
    public string? Titulo {  get; set; }
}
