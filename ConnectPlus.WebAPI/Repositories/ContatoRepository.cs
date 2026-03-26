using ConnectPlus.WebAPI.BdContextConnect;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace ConnectPlus.WebAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ConnectContext _context;

        public ContatoRepository(ConnectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo que atualiza um contato
        /// </summary>
        /// <param name="Id">Id do contato que vai ser atualizado</param>
        /// <param name="contato">Dados do contato</param>
        public void Atualizar(Guid Id, Contato contato)
        {
            var contatoBuscado = _context.Contatos.Find(Id);

            if (contatoBuscado != null)
            {
                contatoBuscado.Nome = string.IsNullOrEmpty(contato.Nome) ? contatoBuscado.Nome : contato.Nome;
                contatoBuscado.FormaContato = string.IsNullOrEmpty(contato.FormaContato) ? contatoBuscado.FormaContato : contato.FormaContato;
                contatoBuscado.Imagem = string.IsNullOrEmpty(contato.Imagem) ? contatoBuscado.Imagem : contato.Imagem;
                contatoBuscado.IdTipoContato = (contato.IdTipoContato == null) ? contatoBuscado.IdTipoContato : contato.IdTipoContato;

                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo que busca um contato por id
        /// </summary>
        /// <param name="Id">Id do contato buscado</param>
        /// <returns>Retorna o contato buscado</returns>
        public Contato BuscarPorId(Guid Id)
        {
            return _context.Contatos.Find(Id)!;
        }

        /// <summary>
        /// Metodo que cadastra um contato
        /// </summary>
        /// <param name="contato">Dados do contato que será cadastrado</param>
        public void Cadastrar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que deleta um contato
        /// </summary>
        /// <param name="Id">Id do contato que será deletado</param>
        public void Deletar(Guid Id)
        {
            var contatoBuscado = _context.Contatos.Find(Id);

            if (contatoBuscado != null)
            {
                _context.Contatos.Remove(contatoBuscado);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo que lista todos os contatos
        /// </summary>
        /// <returns>Retorna uma lista de contatos</returns>
        public List<Contato> Listar()
        {
            return _context.Contatos.OrderBy(e => e.Nome).ToList();
        }
    }
}
