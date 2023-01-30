using Open.Infra.Data.Entities;

namespace Open.Infra.Data.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> Inserir(Pedido pedido);
        Task<Pedido> ObterPorId(int id);
        Task<IList<Pedido>> ObterTodos();
    }
}