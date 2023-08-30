using Microsoft.AspNetCore.Mvc;
using Ejercicio3.Repositories;
using Ejercicio3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejercicio3.Controllers
{
    [ApiController]
    [Route("api/cientificos")]
    public class CientificoController : ControllerBase
    {
        private readonly ICientificoRepository _cientificoRepository;

        public CientificoController(ICientificoRepository cientificoRepository)
        {
            _cientificoRepository = cientificoRepository;
        }

        // Retrieve all cientificos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientifico>>> GetAll()
        {
            var cientificos = await _cientificoRepository.GetAllAsync();
            return Ok(cientificos); // Return 200 OK status
        }

        // Retrieve cientifico by DNI
        [HttpGet("{dni}")]
        public async Task<ActionResult<Cientifico>> GetByDni(string dni)
        {
            var cientifico = await _cientificoRepository.GetByDniAsync(dni);
            if (cientifico == null)
            {
                return NotFound();
            }
            return cientifico; // Return 200 OK status if found
        }

        // Create a new cientifico
        [HttpPost]
        public async Task<ActionResult<Cientifico>> Create(Cientifico cientifico)
        {
            await _cientificoRepository.CreateAsync(cientifico);
            return CreatedAtAction(nameof(GetByDni), new { dni = cientifico.Dni }, cientifico);
            // Return 201 Created status along with the created entity
        }

        // Update an existing cientifico
        [HttpPut("{dni}")]
        public async Task<IActionResult> Update(string dni, Cientifico cientifico)
        {
            if (dni != cientifico.Dni)
            {
                return BadRequest();
            }

            await _cientificoRepository.UpdateAsync(cientifico);
            return NoContent(); // Return 204 No Content status
        }

        // Delete an existing cientifico by DNI
        [HttpDelete("{dni}")]
        public async Task<IActionResult> Delete(string dni)
        {
            var cientifico = await _cientificoRepository.GetByDniAsync(dni);
            if (cientifico == null)
            {
                return NotFound();
            }

            await _cientificoRepository.DeleteAsync(dni);
            return NoContent(); // Return 204 No Content status
        }
    }
}
