using Microsoft.EntityFrameworkCore;
using Open.Infra.Data.Context;
using Open.Infra.Data.Entities;
using Open.Infra.Data.Repositories.Interfaces;

namespace Open.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly MainContext _context;

        public ClienteRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            var novo = _context.Clientes.Find(cliente.Id);
            novo.Atualizar(cliente);
            await _context.SaveChangesAsync();
            return novo;
        }

        public async Task<Cliente> ObterPorId(int id)
        {
            return await _context.Clientes.Include(x => x.Pedidos).ThenInclude(x => x.ItensDoPedido).FirstAsync(x => x.Id == id);
        }

        public async Task<IList<Cliente>> ObterTodos()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}