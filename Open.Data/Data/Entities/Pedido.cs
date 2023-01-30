namespace Open.Infra.Data.Entities
{
    public class Pedido
    {
        private Pedido() { }

        public Pedido(List<ItemDoPedido> itensDoPedido)
        {
            if (itensDoPedido == null || !itensDoPedido.Any())
                throw new Exception("Pedido não pode existir sem ao menos um item!");

            ItensDoPedido = itensDoPedido;
        }

        public int Id { get; set; }
        public string NumeroDoPedido { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public IList<ItemDoPedido> ItensDoPedido { get; set; }

        public decimal ValorTotal
        {
            get
            {
                if (ItensDoPedido == null || !ItensDoPedido.Any())
                    return 0;

                return ItensDoPedido.Sum(x => x.Quantidade * x.ValorUnitario);
            }
        }

        public void GerarNumeroDoPedido()
        {
            NumeroDoPedido =  DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        public void GerarDataDeCriacaoDoPedido()
        {
            DataDeCriacao = DateTime.Now;
        }
    }
}