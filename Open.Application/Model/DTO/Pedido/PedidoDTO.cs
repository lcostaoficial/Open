using Open.Application.Model.DTO.ItemDoPedido;

namespace Open.Application.Model.DTO.Pedido
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string NumeroDoPedido { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public int ClienteId { get; set; }
      
        public IList<ItemDoPedidoDTO> ItensDoPedido { get; set; }

        public decimal ValorTotal
        {
            get
            {
                if (ItensDoPedido == null || !ItensDoPedido.Any())
                    return 0;

                return ItensDoPedido.Sum(x => x.Quantidade * x.ValorUnitario);
            }
        }
    }
}