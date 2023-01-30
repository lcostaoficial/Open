using Open.Business.Services.Interfaces;
using Open.Infra.Data.Entities;
using Open.Infra.Data.Repositories.Interfaces;

namespace Open.Business.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;

        public PedidoService(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Pedido> Inserir(Pedido pedido)
        {
            pedido.GerarNumeroDoPedido();
            pedido.GerarDataDeCriacaoDoPedido();
            return await _repository.Inserir(pedido);
        }

        public async Task<Pedido> ObterPorId(int id)
        {
            return await _repository.ObterPorId(id);
        }

        public async Task<IList<Pedido>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }
    }
}