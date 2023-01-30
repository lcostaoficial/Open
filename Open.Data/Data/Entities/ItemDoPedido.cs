namespace Open.Infra.Data.Entities
{
    public class ItemDoPedido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}