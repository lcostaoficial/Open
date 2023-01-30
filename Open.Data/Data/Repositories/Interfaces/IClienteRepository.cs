using Open.Infra.Data.Entities;

namespace Open.Infra.Data.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Inserir(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task<Cliente> ObterPorId(int id);
        Task<IList<Cliente>> ObterTodos();
    }
}