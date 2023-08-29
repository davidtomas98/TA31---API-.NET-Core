using Microsoft.AspNetCore.Mvc;
using ex03.Repositories;
using ex03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ex03.Controllers
{
    [ApiController]
    [Route("api/proyectos")]
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoRepository _proyectoRepository;

        public ProyectoController(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        // Retrieve all proyectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetAll()
        {
            var proyectos = await _proyectoRepository.GetAllAsync();
            return Ok(proyectos); // Return 200 OK status
        }

        // Retrieve proyecto by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Proyecto>> GetById(string id)
        {
            var proyecto = await _proyectoRepository.GetByIdAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return proyecto; // Return 200 OK status if found
        }

        // Create a new proyecto
        [HttpPost]
        public async Task<ActionResult<Proyecto>> Create(Proyecto proyecto)
        {
            await _proyectoRepository.CreateAsync(proyecto);
            return CreatedAtAction(nameof(GetById), new { id = proyecto.Id }, proyecto);
            // Return 201 Created status along with the created entity
        }

        // Update an existing proyecto
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Proyecto proyecto)
        {
            if (id != proyecto.Id)
            {
                return BadRequest();
            }

            await _proyectoRepository.UpdateAsync(proyecto);
            return NoContent(); // Return 204 No Content status
        }

        // Delete an existing proyecto by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var proyecto = await _proyectoRepository.GetByIdAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }

            await _proyectoRepository.DeleteAsync(id);
            return NoContent(); // Return 204 No Content status
        }
    }
}
