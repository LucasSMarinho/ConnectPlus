using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Interfaces
{
    public interface ITipoContatoRepository
    {
        public void Cadastrar(TipoContato tipoContato);
        public void Atualizar(Guid Id, TipoContato tipoContato);
        public void Deletar(Guid Id);
        public TipoContato BuscarPorId(Guid Id);
        List<TipoContato> Listar();
    };
}
