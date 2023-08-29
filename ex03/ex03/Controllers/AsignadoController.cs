using Microsoft.AspNetCore.Mvc;
using ex03.Repositories;
using ex03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ex03.Controllers
{
    [ApiController]
    [Route("api/asignados")]
    public class AsignadoController : ControllerBase
    {
        private readonly IAsignadoRepository _asignadoRepository;

        // Constructor injection of IAsignadoRepository
        public AsignadoController(IAsignadoRepository asignadoRepository)
        {
            _asignadoRepository = asignadoRepository;
        }

        // Retrieve asignados by cientifico's DNI
        [HttpGet("cientifico/{dni}")]
        public async Task<ActionResult<IEnumerable<Asignado_A>>> GetByCientificoDni(string dni)
        {
            var asignados = await _asignadoRepository.GetByCientificoDniAsync(dni);
            return Ok(asignados); // Return 200 OK status
        }

        // Retrieve asignados by proyecto's ID
        [HttpGet("proyecto/{id}")]
        public async Task<ActionResult<IEnumerable<Asignado_A>>> GetByProyectoId(string id)
        {
            var asignados = await _asignadoRepository.GetByProyectoIdAsync(id);
            return Ok(asignados); // Return 200 OK status
        }

        // Create a new asignado
        [HttpPost]
        public async Task<ActionResult<Asignado_A>> Create(Asignado_A asignado)
        {
            await _asignadoRepository.CreateAsync(asignado);
            return CreatedAtAction(nameof(GetByCientificoDni), new { dni = asignado.CientificoDni }, asignado);
            // Return 201 Created status along with the created entity
        }

        // Update an existing asignado
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Asignado_A asignado)
        {
            if (id != asignado.Id)
            {
                return BadRequest();
            }

            await _asignadoRepository.UpdateAsync(asignado);
            return NoContent(); // Return 204 No Content status
        }

        // Delete an existing asignado by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignado(int id)
        {
            var asignado = await _asignadoRepository.GetByIdAsync(id);
            if (asignado == null)
            {
                return NotFound();
            }

            await _asignadoRepository.DeleteAsync(id);
            return NoContent(); // Return 204 No Content status
        }
    }
}
