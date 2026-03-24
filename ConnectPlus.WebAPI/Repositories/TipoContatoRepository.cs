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

        public void Atualizar(Guid Id, TipoContato tipoContato)
        {
            var TipoContatoBuscado = _context.TipoContatos.Find(Id);

            if (TipoContatoBuscado != null)
            {
                _context.TipoContatos.Update(TipoContatoBuscado);
                _context.SaveChanges();
            }
        }

        public TipoContato BuscarPorId(Guid Id)
        {
            return _context.TipoContatos.Find(Id)!;
        }

        public void Cadastrar(TipoContato tipoContato)
        {
            _context.TipoContatos.Add(tipoContato);
            _context.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            var TipoContatoBuscado = _context.TipoContatos.Find(Id);

            if (TipoContatoBuscado != null)
            {
                _context.TipoContatos.Remove(TipoContatoBuscado);
                _context.SaveChanges();
            };
        }

        public List<TipoContato> Listar()
        {
            return _context.TipoContatos.ToList();
        }
    }
}
