using Open.Infra.Data.Entities;
using Xunit;

namespace Open.Tests.Unit.Model
{
    public class ItemPedidoTests
    {
        [Fact]
        public void CalculoDoValorTotalDoItemPedido()
        {
            // Arrange
            var itemDoPedido = new ItemDoPedido
            {
                Id = 10,
                Nome = "Calça Jeans",
                ValorUnitario = 100.00m,
                Quantidade = 2
            };

            // Act
            var valorTotal = itemDoPedido.ValorUnitario * itemDoPedido.Quantidade;

            // Assert
            Assert.Equal(200.00m, valorTotal);
        }

        [Fact]
        public void AtribuicaoDePropriedades()
        {
            // Arrange
            var itemDoPedido = new ItemDoPedido
            {
                Id = 10,
                Nome = "Calça Jeans",
                ValorUnitario = 100.00m,
                Quantidade = 2,
                PedidoId = 5
            };

            // Assert
            Assert.Equal(10, itemDoPedido.Id);
            Assert.Equal("Calça Jeans", itemDoPedido.Nome);
            Assert.Equal(100.00m, itemDoPedido.ValorUnitario);
            Assert.Equal(2, itemDoPedido.Quantidade);
            Assert.Equal(5, itemDoPedido.PedidoId);
        }
    }
}
