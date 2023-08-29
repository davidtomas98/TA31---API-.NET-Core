using ex03.Models;

namespace ex03.Repositories
{
    /// <summary>
    /// Interface for the repository handling 'Asignado_A' entities.
    /// </summary>
    public interface IAsignadoRepository
    {
        /// <summary>
        /// Retrieves a list of assignments associated with a scientist's DNI.
        /// </summary>
        Task<IEnumerable<Asignado_A>> GetByCientificoDniAsync(string dni);

        /// <summary>
        /// Retrieves a list of assignments associated with a project's ID.
        /// </summary>
        Task<IEnumerable<Asignado_A>> GetByProyectoIdAsync(string id);

        /// <summary>
        /// Retrieves an assignment by its ID.
        /// </summary>
        Task<Asignado_A> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new assignment.
        /// </summary>
        Task CreateAsync(Asignado_A asignado);

        /// <summary>
        /// Updates an existing assignment.
        /// </summary>
        Task UpdateAsync(Asignado_A asignado);

        /// <summary>
        /// Deletes an assignment by its ID.
        /// </summary>
        Task DeleteAsync(int id);
    }
}
