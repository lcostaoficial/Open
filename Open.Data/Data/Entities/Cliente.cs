namespace Open.Infra.Data.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public IList<Pedido> Pedidos { get; private set; }

        public void Atualizar(Cliente cliente)
        {
            Nome = cliente.Nome;
            Email = cliente.Email;  
        }   
    }
}