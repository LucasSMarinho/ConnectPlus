using ConnectPlus.WebAPI.DTO;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConnectPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz chamada ao metodo de listar os contatos
    /// </summary>
    /// <returns>Retorna uma lista de contatos</returns>
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_contatoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoind da API que faz chamado ao metodo de buscar um contato por id
    /// </summary>
    /// <param name="id">Id do contato buscado</param>
    /// <returns>Retorna o contato buscado</returns>
    [HttpGet("{id}")]

    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamado ao metodo de cadastrar um contato
    /// </summary>
    /// <param name="contato">Dados do contato</param>
    /// <returns>Retorna StatosCode 201 e o novo contato</returns>
    [HttpPost]

    public async Task<IActionResult> Post([FromForm] ContatoDTO contato)
    {

        var novoContato = new Contato();

        if (contato.Imagem != null && contato.Imagem.Length > 0)
        {
            var extensao = Path.GetExtension(contato.Imagem.FileName);

            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/imagens";
            var caminhaPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            //Para garantir que a pasta exista
            if (!Directory.Exists(caminhaPasta))
                Directory.CreateDirectory(caminhaPasta);

            var caminhoCompleto = Path.Combine(caminhaPasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await contato.Imagem.CopyToAsync(stream);
            }

            novoContato.Imagem = nomeArquivo;

        }

        novoContato.Nome = contato.Nome!; 
        novoContato.FormaContato = contato.FormaContato!;
        novoContato.IdTipoContato = contato.IdTipoContato;

        try
        {
            _contatoRepository.Cadastrar(novoContato);
            return StatusCode(201, novoContato);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamado ao metodo de atualizar um contato
    /// </summary>
    /// <param name="id">Id do contato a ser atualizado</param>
    /// <param name="contatoAtualizado">Novos dados do contato</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, contatoDTOatualizado contatoAtualizado)
    {
        var contatoBuscado = _contatoRepository.BuscarPorId(id);
        if (contatoBuscado == null)
            return NotFound("Contato não encontrado");

        if (!string.IsNullOrEmpty(contatoAtualizado.Nome))
            contatoBuscado.Nome = contatoAtualizado.Nome;

        if (contatoAtualizado.Imagem != null && contatoAtualizado.Imagem.Length > 0)
        {
            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            //Deleta arquivo antigo
            if (!string.IsNullOrEmpty(contatoBuscado.Imagem))
            {
                var caminhoAntigo = Path.Combine(caminhoPasta, contatoBuscado.Imagem);
                if (System.IO.File.Exists(caminhoAntigo))
                    System.IO.File.Delete(caminhoAntigo);
            }

            var extensao = Path.GetExtension(contatoAtualizado.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await contatoAtualizado.Imagem.CopyToAsync(stream);
            }

            contatoBuscado.Imagem = string.IsNullOrEmpty(nomeArquivo) ? contatoBuscado.Imagem : nomeArquivo;
            contatoBuscado.IdTipoContato = contatoAtualizado.IdTipoContato;

        }

        try
        {
            _contatoRepository.Atualizar(id, contatoBuscado);
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamado ao metodo de deletar 
    /// </summary>
    /// <param name="id">Id do contato a ser deletado</param>
    /// <returns>Retorna no content</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {

        var contatoBuscado = _contatoRepository.BuscarPorId(id);

        if (contatoBuscado == null)
            return NotFound("Contato não encontrado");

        var pastaRelativa = "wwwroot/imagens";
        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

        //Deleta o arquivo

        if (!string.IsNullOrEmpty(contatoBuscado.Imagem))
        {
            var caminho = Path.Combine(caminhoPasta, contatoBuscado.Imagem);

            if (System.IO.File.Exists(caminho))
                System.IO.File.Delete(caminho);
        }

        try
        {
            _contatoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
