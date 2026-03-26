using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Interfaces;

public interface IContatoRepository
{
    public void Cadastrar(Contato contato);
    public void Atualizar(Guid Id, Contato contato);
    public void Deletar(Guid Id);
    public Contato BuscarPorId(Guid Id);
    List<Contato> Listar();
}
