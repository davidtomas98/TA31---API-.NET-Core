using ex03.Data;
using ex03.Models;
using Microsoft.EntityFrameworkCore;

namespace ex03.Repositories
{
    /// <summary>
    /// Repository class for managing 'Asignado_A' entities in the database.
    /// </summary>
    public class AsignadoRepository : IAsignadoRepository
    {
        private readonly AppDbContext _dbContext;

        public AsignadoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Asignado_A>> GetByCientificoDniAsync(string dni)
        {
            // Retrieve a list of assignments for a scientist with the specified DNI
            return await _dbContext.Asignados
                .Where(a => a.CientificoDni == dni)
                .ToListAsync();
        }

        public async Task<IEnumerable<Asignado_A>> GetByProyectoIdAsync(string id)
        {
            // Retrieve a list of assignments for a project with the specified ID
            return await _dbContext.Asignados
                .Where(a => a.ProyectoId == id)
                .ToListAsync();
        }

        public async Task<Asignado_A> GetByIdAsync(int id)
        {
            // Retrieve an assignment by its ID
            return await _dbContext.Asignados.FindAsync(id);
        }

        public async Task CreateAsync(Asignado_A asignado)
        {
            // Add a new assignment to the database
            _dbContext.Asignados.Add(asignado);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Asignado_A asignado)
        {
            // Update an existing assignment in the database
            _dbContext.Entry(asignado).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Delete an assignment by its ID
            var asignado = await _dbContext.Asignados.FindAsync(id);
            if (asignado != null)
            {
                _dbContext.Asignados.Remove(asignado);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
