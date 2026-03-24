using ConnectPlus.WebAPI.DTO;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoContatoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoContatoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoContatoDTO tipoContato)
        {
            try
            {
                var novoTipoContato = new TipoContato
                {
                    Titulo = tipoContato.Titulo
                };

                _tipoContatoRepository.Cadastrar(novoTipoContato);
                return StatusCode(201, novoTipoContato);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, TipoContatoDTO tipoContato)
        {
            try
            {
                var novoTipoContato = new TipoContato
                {
                    Titulo = tipoContato.Titulo
                };

                _tipoContatoRepository.Atualizar(id, novoTipoContato);
                return StatusCode(201, novoTipoContato);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _tipoContatoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
