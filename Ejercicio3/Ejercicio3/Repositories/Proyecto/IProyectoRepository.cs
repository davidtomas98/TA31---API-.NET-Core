using Ejercicio3.Models;

namespace Ejercicio3.Repositories
{
    /// <summary>
    /// Interface for the repository handling 'Proyecto' entities.
    /// </summary>
    public interface IProyectoRepository
    {
        /// <summary>
        /// Retrieves a project by its ID.
        /// </summary>
        Task<Proyecto> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves a list of all projects.
        /// </summary>
        Task<IEnumerable<Proyecto>> GetAllAsync();

        /// <summary>
        /// Creates a new project.
        /// </summary>
        Task CreateAsync(Proyecto proyecto);

        /// <summary>
        /// Updates an existing project.
        /// </summary>
        Task UpdateAsync(Proyecto proyecto);

        /// <summary>
        /// Deletes a project by its ID.
        /// </summary>
        Task DeleteAsync(string id);
    }
}
