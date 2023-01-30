using Open.Infra.Data.Entities;

namespace Open.Business.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> Inserir(Pedido pedido);
        Task<Pedido> ObterPorId(int id);
        Task<IList<Pedido>> ObterTodos();
    }
}