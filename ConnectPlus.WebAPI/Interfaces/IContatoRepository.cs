using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Interfaces
{
    public interface IContatoRepository
    {
        public void Cadastrar();
        public void Atualizar(Guid Id);
        public void Deletar(Guid Id);
        public Contato BuscarPorId(Guid Id);
        List<Contato> Listar();
    }
}
