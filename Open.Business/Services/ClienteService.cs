using Open.Business.Services.Interfaces;
using Open.Infra.Data.Entities;
using Open.Infra.Data.Repositories.Interfaces;

namespace Open.Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository) { 
        
            _repository = repository;
        }

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            return await _repository.Inserir(cliente);
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            return await _repository.Atualizar(cliente);
        }

        public async Task<Cliente> ObterPorId(int id)
        {
            return await _repository.ObterPorId(id);
        }

        public async Task<IList<Cliente>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }
    }
}