using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Open.Application.Model.DTO.Pedido;
using Open.Business.Services.Interfaces;
using Open.Infra.Data.Entities;

namespace Open.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var retorno = await _service.ObterTodos();

            if (!retorno.Any())
                return NotFound();

            return Ok(_mapper.Map<IList<PedidoDTO>>(retorno));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var retorno = await _service.ObterPorId(id);

            if (retorno == null)
                return NotFound();

            return Ok(_mapper.Map<PedidoDTO>(retorno));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InserirPedidoDTO pedido)
        {
            if (pedido == null || pedido.ClienteId == 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (pedido.ItensDoPedido == null || !pedido.ItensDoPedido.Any())
                return BadRequest(ModelState);

            var retorno = await _service.Inserir(_mapper.Map<Pedido>(pedido));

            return Ok(_mapper.Map<PedidoDTO>(retorno));
        }
    }
}