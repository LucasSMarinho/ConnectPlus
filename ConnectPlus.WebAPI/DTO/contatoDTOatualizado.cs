using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.WebAPI.Controllers
{
    public class contatoDTOatualizado
    {
        public string? Nome { get; set; }
        public IFormFile? Imagem { get; set; }
        public string? FormaContato { get; set; }
        public Guid IdTipoContato { get; set; }
    }
}
