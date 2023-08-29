using ex03.Models;

namespace ex03.Repositories
{
    /// <summary>
    /// Interface for the repository handling 'Cientifico' entities.
    /// </summary>
    public interface ICientificoRepository
    {
        /// <summary>
        /// Retrieves a scientist by their DNI.
        /// </summary>
        Task<Cientifico> GetByDniAsync(string dni);

        /// <summary>
        /// Retrieves a list of all scientists.
        /// </summary>
        Task<IEnumerable<Cientifico>> GetAllAsync();

        /// <summary>
        /// Creates a new scientist.
        /// </summary>
        Task CreateAsync(Cientifico cientifico);

        /// <summary>
        /// Updates an existing scientist.
        /// </summary>
        Task UpdateAsync(Cientifico cientifico);

        /// <summary>
        /// Deletes a scientist by their DNI.
        /// </summary>
        Task DeleteAsync(string dni);
    }
}
