using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Open.Application.Model.DTO.Cliente
{
    public class InserirClienteDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Este campo permite no máximo 100 caracteres")]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(1000, ErrorMessage = "Este campo permite no máximo 1000 caracteres")]
        [EmailAddress(ErrorMessage = "E-mail não é válido!")]
        [JsonProperty(Required = Required.DisallowNull)]
        public string Email { get; set; }
    }
}