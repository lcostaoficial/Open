namespace Open.Application.Model.DTO.ItemDoPedido
{
    public class ItemDoPedidoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public int PedidoId { get; set; }
    }
}