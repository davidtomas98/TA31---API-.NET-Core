using Microsoft.AspNetCore.Mvc;
using Ejercicio2.Repositories;
using Ejercicio2.Models;

namespace Ejercicio2.Controllers
{
    // Controlador que maneja las operaciones CRUD para la entidad Video.
    [ApiController]
    [Route("api/videos")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository _videoRepository;

        public VideoController(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        // Obtiene todos los videos.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var videos = await _videoRepository.GetAllAsync();
            return Ok(videos);
        }

        // Obtiene un video por su ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        // Crea un nuevo video.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Video video)
        {
            if (ModelState.IsValid)
            {
                await _videoRepository.CreateAsync(video);
                return CreatedAtAction(nameof(GetById), new { id = video.Id }, video);
            }
            return BadRequest(ModelState);
        }

        // Actualiza un video existente.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _videoRepository.UpdateAsync(video);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // Elimina un video por su ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            await _videoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
