using Open.Infra.Data.Entities;
using Xunit;

namespace Open.Tests.Unit.Model
{
    public class ClienteTests
    {
        [Fact]
        public void AtualizacaoDoCliente()
        {
            // Arrange
            var cliente = new Cliente { Id = 1, Nome = "Teste", Email = "teste@teste.com" };
            var clienteAtualizado = new Cliente { Id = 1, Nome = "Teste 2", Email = "teste2@teste.com" };

            // Act
            cliente.Atualizar(clienteAtualizado);

            // Assert
            Assert.Equal(clienteAtualizado.Nome, cliente.Nome);
            Assert.Equal(clienteAtualizado.Email, cliente.Email);
        }
    }
}