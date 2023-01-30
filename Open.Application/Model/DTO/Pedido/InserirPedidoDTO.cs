using System.ComponentModel.DataAnnotations;
using Open.Application.Model.DTO.ItemDoPedido;

namespace Open.Application.Model.DTO.Pedido
{
    public class InserirPedidoDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int ClienteId { get; set; }

        [Required]
        [MinLength(1)]
        public IList<InserirItemDoPedidoDTO> ItensDoPedido { get; set; }
    }
}