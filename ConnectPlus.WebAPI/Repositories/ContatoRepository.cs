using ConnectPlus.WebAPI.BdContextConnect;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ConnectContext _context;

        public ContatoRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Contato BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar()
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Contato> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
