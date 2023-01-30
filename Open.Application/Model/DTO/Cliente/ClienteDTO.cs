using Open.Application.Model.DTO.Pedido;

namespace Open.Application.Model.DTO.Cliente
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<PedidoDTO> Pedidos { get; set; }
    }
}