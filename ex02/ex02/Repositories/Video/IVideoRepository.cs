using ex02.Models;

namespace ex02.Repositories
{
    // Interfaz que define los métodos del repositorio de videos.
    public interface IVideoRepository
    {
        // Obtener un video por su ID de manera asincrónica.
        Task<Video> GetByIdAsync(int id);

        // Obtener todos los videos de manera asincrónica.
        Task<IEnumerable<Video>> GetAllAsync();

        // Crear un nuevo video de manera asincrónica.
        Task CreateAsync(Video video);

        // Actualizar un video existente de manera asincrónica.
        Task UpdateAsync(Video video);

        // Eliminar un video por su ID de manera asincrónica.
        Task DeleteAsync(int id);
    }
}
