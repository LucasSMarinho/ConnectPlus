using ConnectPlus.WebAPI.BdContextConnect;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Repositories
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        private readonly ConnectContext _context;

        public TipoContatoRepository(ConnectContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo da API que atualiza um tipo contato
        /// </summary>
        /// <param name="Id">Id do tipo de contato que será atualizado</param>
        /// <param name="tipoContato"> Dados do tipo contato</param>
        public void Atualizar(Guid Id, TipoContato tipoContato)
        {
            var TipoContatoBuscado = _context.TipoContatos.Find(Id);

            if (TipoContatoBuscado != null)
            {
                TipoContatoBuscado.Titulo = tipoContato.Titulo;

                _context.TipoContatos.Update(TipoContatoBuscado);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo que busca um tipo de contato por id
        /// </summary>
        /// <param name="Id">Id do tipo contato buscado</param>
        /// <returns>retorna o tipo contato</returns>
        public TipoContato BuscarPorId(Guid Id)
        {
            return _context.TipoContatos.Find(Id)!;
        }

        /// <summary>
        /// Metodo que cadastra um tipo de contato
        /// </summary>
        /// <param name="tipoContato">Dados do novo tipo de contato</param>
        public void Cadastrar(TipoContato tipoContato)
        {
            _context.TipoContatos.Add(tipoContato);
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que deleta um tipo de contato
        /// </summary>
        /// <param name="Id">Id do tipo de contato que será deletado</param>
        public void Deletar(Guid Id)
        {
            var TipoContatoBuscado = _context.TipoContatos.Find(Id);

            if (TipoContatoBuscado != null)
            {
                _context.TipoContatos.Remove(TipoContatoBuscado);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo que lista todos os tipos de contato
        /// </summary>
        /// <returns>Retorna uma lista dos tipos de contato</returns>
        public List<TipoContato> Listar()
        {
            return _context.TipoContatos.ToList();
        }
    }
}
