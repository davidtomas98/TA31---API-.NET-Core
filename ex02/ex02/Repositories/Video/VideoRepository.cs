using ex02.Data;
using ex02.Models;
using Microsoft.EntityFrameworkCore;

namespace ex02.Repositories
{
    // Implementación del repositorio de videos.
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _dbContext;

        public VideoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtener un video por su ID.
        public async Task<Video> GetByIdAsync(int id)
        {
            return await _dbContext.Videos.FindAsync(id);
        }

        // Obtener todos los videos.
        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _dbContext.Videos.ToListAsync();
        }

        // Crear un nuevo video.
        public async Task CreateAsync(Video video)
        {
            _dbContext.Videos.Add(video);
            await _dbContext.SaveChangesAsync();
        }

        // Actualizar un video existente.
        public async Task UpdateAsync(Video video)
        {
            _dbContext.Entry(video).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Eliminar un video por su ID.
        public async Task DeleteAsync(int id)
        {
            var video = await _dbContext.Videos.FindAsync(id);
            if (video != null)
            {
                _dbContext.Videos.Remove(video);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
