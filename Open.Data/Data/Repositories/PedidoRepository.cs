using Microsoft.EntityFrameworkCore;
using Open.Infra.Data.Context;
using Open.Infra.Data.Entities;
using Open.Infra.Data.Repositories.Interfaces;

namespace Open.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        protected readonly MainContext _context;

        public PedidoRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<Pedido> Inserir(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> ObterPorId(int id)
        {
            return await _context.Pedidos.Include(x => x.ItensDoPedido).FirstAsync(x => x.Id == id);
        }

        public async Task<IList<Pedido>> ObterTodos()
        {
            return await _context.Pedidos.ToListAsync();
        }
    }
}