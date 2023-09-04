using Ejercicio3.Data;
using Ejercicio3.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio3.Repositories
{
    /// <summary>
    /// Repository class for managing 'Cientifico' entities in the database.
    /// </summary>
    public class CientificoRepository : ICientificoRepository
    {
        private readonly APIContext _dbContext;

        public CientificoRepository(APIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cientifico> GetByDniAsync(string dni)
        {
            // Retrieve a scientist by their DNI
            return await _dbContext.Cientificos.FindAsync(dni);
        }

        public async Task<IEnumerable<Cientifico>> GetAllAsync()
        {
            // Retrieve a list of all scientists
            return await _dbContext.Cientificos.ToListAsync();
        }

        public async Task CreateAsync(Cientifico cientifico)
        {
            // Add a new scientist to the database
            _dbContext.Cientificos.Add(cientifico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cientifico cientifico)
        {
            // Update an existing scientist in the database
            _dbContext.Entry(cientifico).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string dni)
        {
            // Delete a scientist by their DNI
            var cientifico = await _dbContext.Cientificos.FindAsync(dni);
            if (cientifico != null)
            {
                _dbContext.Cientificos.Remove(cientifico);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
