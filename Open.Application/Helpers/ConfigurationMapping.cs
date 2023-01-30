using AutoMapper;
using Open.Application.Model.DTO.Cliente;
using Open.Application.Model.DTO.ItemDoPedido;
using Open.Application.Model.DTO.Pedido;
using Open.Infra.Data.Entities;

namespace Open.Application.Helpers
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            //Cliente
            CreateMap<Cliente, InserirClienteDTO>().ReverseMap();
            CreateMap<Cliente, AtualizarClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            //ItemDoPedido
            CreateMap<ItemDoPedido, InserirItemDoPedidoDTO>().ReverseMap();
            CreateMap<ItemDoPedido, ItemDoPedidoDTO>().ReverseMap();

            //Pedido
            CreateMap<Pedido, InserirPedidoDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
        }
    }
}