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

        /// <summary>
        /// Endpoint da API que faz chamado ao metodo de de listar os tipos de contato
        /// </summary>
        /// <returns>Retorna Status Code 200 e a lista dos tipos de contato</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id do</param>
        /// <returns></returns>
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

        /// <summary>
        /// Endpoint da API que faz chamado ao metodo de cadastrar um tipo de usuario
        /// </summary>
        /// <param name="tipoContato">Dados do tipo contato</param>
        /// <returns>Retorna StatusCode 201 e o novo tipo contato</returns>
        [HttpPost]
        public IActionResult Post(TipoContatoDTO tipoContato)
        {
            try
            {
                var novoTipoContato = new TipoContato
                {
                    Titulo = tipoContato.Titulo!
                };

                _tipoContatoRepository.Cadastrar(novoTipoContato);
                return StatusCode(201, novoTipoContato);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamado ao metodo de atualizar um
        /// </summary>
        /// <param name="id">Id do tipo contato que será atualizado</param>
        /// <param name="tipoContato">Novos dados do tipo contato</param>
        /// <returns>Retorna Status Code 201 e o novo tipo contato</returns>
        [HttpPut]
        public IActionResult Put(Guid id, TipoContatoDTO tipoContato)
        {
            try
            {
                var novoTipoContato = new TipoContato
                {
                    Titulo = tipoContato.Titulo!
                };

                _tipoContatoRepository.Atualizar(id, novoTipoContato);
                return StatusCode(201, _tipoContatoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da API que faz chamado ao metodo de deletar um tipo de contato
        /// </summary>
        /// <param name="id">Id do tipo de contato que será deletado</param>
        /// <returns>retorna no content</returns>
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
