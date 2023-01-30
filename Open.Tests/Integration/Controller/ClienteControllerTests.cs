using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Open.Application.Controllers;
using Open.Application.Model.DTO.Cliente;
using Open.Business.Services.Interfaces;
using Open.Infra.Data.Entities;
using Xunit;

namespace Open.Tests.Integration.Controller
{
    public class ClienteControllerTests
    {
        private readonly Mock<IClienteService> _clienteService;
        private readonly Mock<IMapper> _mapper;
        private readonly ClienteController _controller;

        public ClienteControllerTests()
        {
            _clienteService = new Mock<IClienteService>();
            _mapper = new Mock<IMapper>();
            _controller = new ClienteController(_clienteService.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetDeRetornoOK()
        {
            // Arrange
            var clientes = new List<Cliente>
            {
                new Cliente { Id = 1, Nome = "John Doe" },
                new Cliente { Id = 2, Nome = "Jane Doe" },
                new Cliente { Id = 3, Nome = "Paul Smith" }
            };

            var clienteDtos = new List<ClienteDTO>
            {
                new ClienteDTO { Id = 1, Nome = "John Doe" },
                new ClienteDTO { Id = 2, Nome = "Jane Doe" },
                new ClienteDTO { Id = 3, Nome = "Paul Smith" }
            };

            _clienteService
                .Setup(x => x.ObterTodos())
                .ReturnsAsync(clientes);

            _mapper
                .Setup(x => x.Map<IList<ClienteDTO>>(clientes))
                .Returns(clienteDtos);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(clienteDtos, okResult.Value);
        }

        [Fact]
        public async Task GetDeRetornoNotFound()
        {
            // Arrange
            var clientes = new List<Cliente>();

            _clienteService
                .Setup(x => x.ObterTodos())
                .ReturnsAsync(clientes);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetPorIdDeRetornoOk()
        {
            // Arrange
            var cliente = new Cliente { Id = 1, Nome = "John Doe" };
            var clienteDto = new ClienteDTO { Id = 1, Nome = "John Doe" };

            _clienteService
                .Setup(x => x.ObterPorId(cliente.Id))
                .ReturnsAsync(cliente);

            _mapper
                .Setup(x => x.Map<ClienteDTO>(cliente))
                .Returns(clienteDto);

            // Act
            var result = await _controller.Get(cliente.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(clienteDto, okResult.Value);
        }

        [Fact]
        public async Task GetPorIdDeRetornoNotFound()
        {
            // Arrange
            _clienteService
                .Setup(x => x.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _controller.Get(It.IsAny<int>());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PostDeRetornoBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Ocorreu um erro.");

            // Act
            var result = await _controller.Post(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostDeRetornoOk()
        {
            // Arrange
            var cliente = new InserirClienteDTO
            {
                Nome = "John Doe"
            };
            var clienteEntity = new Cliente
            {
                Id = 1,
                Nome = "John Doe"
            };
            var clienteDto = new ClienteDTO
            {
                Id = 1,
                Nome = "John Doe"
            };

            _mapper
                .Setup(x => x.Map<Cliente>(cliente))
                .Returns(clienteEntity);

            _clienteService
                .Setup(x => x.Inserir(clienteEntity))
                .ReturnsAsync(clienteEntity);

            _mapper
                .Setup(x => x.Map<ClienteDTO>(clienteEntity))
                .Returns(clienteDto);

            // Act
            var result = await _controller.Post(cliente);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(clienteDto, okResult.Value);
        }

        [Fact]
        public async Task PutDeRetornoBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("Error", "Ocorreu um erro.");

            // Act
            var result = await _controller.Put(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PutDeRetornoNotFound()
        {
            // Arrange
            var cliente = new AtualizarClienteDTO { Id = 1 };

            _clienteService
                .Setup(x => x.ObterPorId(cliente.Id))
                .ReturnsAsync(() => null);

            // Act
            var result = await _controller.Put(new AtualizarClienteDTO { Id = 1 });

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutDeRetornoOk()
        {
            // Arrange
            var cliente = new AtualizarClienteDTO
            {
                Id = 1,
                Nome = "John Doe"
            };
            var clienteEntity = new Cliente
            {
                Id = 1,
                Nome = "John Doe"
            };

            _mapper
                .Setup(x => x.Map<Cliente>(cliente))
                .Returns(clienteEntity);

            _clienteService
                .Setup(x => x.ObterPorId(cliente.Id))
                .ReturnsAsync(clienteEntity);

            _clienteService
                .Setup(x => x.Atualizar(clienteEntity))
                .ReturnsAsync(clienteEntity);

            // Act
            var result = await _controller.Put(cliente);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(cliente, okResult.Value);
        }
    }
}