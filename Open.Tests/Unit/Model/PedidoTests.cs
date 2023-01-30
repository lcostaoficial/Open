using Open.Infra.Data.Entities;
using Xunit;

namespace Open.Tests.Unit.Model
{
    public class PedidoTests
    {
        [Fact]
        public void ValorTotalEsperado()
        {
            //Arrange           
            var itensDoPedido = new List<ItemDoPedido>
            {
                new ItemDoPedido{ Quantidade = 2, ValorUnitario = 10 },
                new ItemDoPedido{ Quantidade = 1, ValorUnitario = 5 }
            };

            var pedido = new Pedido(itensDoPedido);
            decimal valorEsperado = 25;

            //Act
            var valorTotal = pedido.ValorTotal;

            //Assert
            Assert.Equal(valorEsperado, valorTotal);
        }

        [Fact]
        public void GeradorDoNumeroDoPedido()
        {
            //Arrange
            var itensDoPedido = new List<ItemDoPedido>()
            {
                new ItemDoPedido { Nome = "Bola", Quantidade = 1, ValorUnitario = 10.0m }
            };

            var pedido = new Pedido(itensDoPedido);

            //Act
            pedido.GerarNumeroDoPedido();

            var numeroDoPedido = pedido.NumeroDoPedido;

            //Assert
            Assert.NotEmpty(numeroDoPedido);
        }

        [Fact]
        public void GeradorDaDataDeCriacaoDoPedido()
        {
            //Arrange
            var itensDoPedido = new List<ItemDoPedido>()
            {
                new ItemDoPedido { Nome = "Bola", Quantidade = 1, ValorUnitario = 10.0m }
            };

            var pedido = new Pedido(itensDoPedido);

            //Act
            pedido.GerarDataDeCriacaoDoPedido();

            var dataDeCriacaoDoPedido = pedido.DataDeCriacao;

            //Assert
            Assert.NotEqual(DateTime.MinValue, dataDeCriacaoDoPedido);
        }

        [Fact]
        public void ProtecaoDoConstrutorDoPedido()
        {
            //Act
            var listaVaziaDeItens = new List<ItemDoPedido>();

            var exception = Record.Exception(() => new Pedido(listaVaziaDeItens));

            //Assert
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
        }
    }
}