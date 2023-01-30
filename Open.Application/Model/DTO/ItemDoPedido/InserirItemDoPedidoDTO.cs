using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Open.Application.Model.DTO.ItemDoPedido
{
    public class InserirItemDoPedidoDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, ErrorMessage = "Este campo permite no máximo 100 caracteres")]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [JsonProperty(Required = Required.DisallowNull)]
        public decimal ValorUnitario { get; set; }

        [Required(ErrorMessage = "Quantidade")]
        [JsonProperty(Required = Required.DisallowNull)]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade do produto deve ser maior que zero")]
        public int Quantidade { get; set; }
    }
}