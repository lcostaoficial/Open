using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Open.Application.Model.DTO.Cliente;
using Open.Business.Services.Interfaces;
using Open.Infra.Data.Entities;

namespace Open.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService service, IMapper mapper)
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

            return Ok(_mapper.Map<IList<ClienteDTO>>(retorno));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var retorno = await _service.ObterPorId(id);

            if (retorno == null)
                return NotFound();

            return Ok(_mapper.Map<ClienteDTO>(retorno));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InserirClienteDTO cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _service.Inserir(_mapper.Map<Cliente>(cliente));

            return Ok(_mapper.Map<ClienteDTO>(retorno));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AtualizarClienteDTO cliente)
        {
            if (cliente == null || cliente.Id == 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clienteExistente = await _service.ObterPorId(cliente.Id);

            if (clienteExistente == null)
                return NotFound();

            var retorno = await _service.Atualizar((_mapper.Map<Cliente>(cliente)));

            return Ok(cliente);
        }
    }
}