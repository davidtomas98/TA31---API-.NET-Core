using Microsoft.AspNetCore.Mvc;
using ex01.Repositories;
using ex01.Models;

namespace ex01.Controllers
{
    // Define que esta clase es un controlador para API y define la ruta base para las acciones.
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        // Constructor que recibe una instancia del repositorio de clientes mediante inyección de dependencias.
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Acción para obtener un cliente por su ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            // Si el cliente no existe, devuelve un resultado 404 (No encontrado).
            if (cliente == null)
            {
                return NotFound();
            }

            // Devuelve el cliente encontrado con un resultado 200 (OK).
            return Ok(cliente);
        }

        // Acción para obtener todos los clientes.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();

            // Devuelve la lista de clientes con un resultado 200 (OK).
            return Ok(clientes);
        }

        // Acción para crear un nuevo cliente.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            // Verifica si el modelo recibido es válido según las reglas de validación definidas en el modelo.
            if (ModelState.IsValid)
            {
                await _clienteRepository.CreateAsync(cliente);

                // Retorna un resultado 201 (Creado) junto con la información del cliente recién creado.
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }

            // Si el modelo no es válido, devuelve un resultado 400 (Solicitud incorrecta) con los errores de validación.
            return BadRequest(ModelState);
        }

        // Acción para actualizar un cliente existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            // Verifica si el ID en la ruta coincide con el ID del cliente en el cuerpo de la solicitud.
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            // Verifica si el modelo recibido es válido.
            if (ModelState.IsValid)
            {
                await _clienteRepository.UpdateAsync(cliente);

                // Retorna un resultado 204 (Sin contenido) para indicar que la actualización se realizó con éxito.
                return NoContent();
            }

            // Si el modelo no es válido, devuelve un resultado 400 (Solicitud incorrecta) con los errores de validación.
            return BadRequest(ModelState);
        }

        // Acción para eliminar un cliente por su ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteRepository.DeleteAsync(id);

            // Retorna un resultado 204 (Sin contenido) para indicar que la eliminación se realizó con éxito.
            return NoContent();
        }
    }
}
