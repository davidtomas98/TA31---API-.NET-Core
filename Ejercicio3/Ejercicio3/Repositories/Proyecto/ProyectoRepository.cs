using Ejercicio3.Data;
using Ejercicio3.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio3.Repositories
{
    /// <summary>
    /// Repository class for managing 'Proyecto' entities in the database.
    /// </summary>
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly APIContext _dbContext;

        public ProyectoRepository(APIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Proyecto> GetByIdAsync(string id)
        {
            // Retrieve a project by its ID
            return await _dbContext.Proyectos.FindAsync(id);
        }

        public async Task<IEnumerable<Proyecto>> GetAllAsync()
        {
            // Retrieve a list of all projects
            return await _dbContext.Proyectos.ToListAsync();
        }

        public async Task CreateAsync(Proyecto proyecto)
        {
            // Add a new project to the database
            _dbContext.Proyectos.Add(proyecto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Proyecto proyecto)
        {
            // Update an existing project in the database
            _dbContext.Entry(proyecto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            // Delete a project by its ID
            var proyecto = await _dbContext.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _dbContext.Proyectos.Remove(proyecto);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
