using Microsoft.AspNetCore.Mvc;
using Ejercicio2.Repositories;
using Ejercicio2.Models;

namespace Ejercicio2.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Obtiene un cliente por su ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // Obtiene todos los clientes.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        // Crea un nuevo cliente.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteRepository.CreateAsync(cliente);
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }
            return BadRequest(ModelState);
        }

        // Actualiza un cliente existente por su ID.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _clienteRepository.UpdateAsync(cliente);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // Elimina un cliente por su ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
