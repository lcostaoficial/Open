using Open.Infra.Data.Entities;

namespace Open.Business.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> Inserir(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task<Cliente> ObterPorId(int id);
        Task<IList<Cliente>> ObterTodos();
    }
}