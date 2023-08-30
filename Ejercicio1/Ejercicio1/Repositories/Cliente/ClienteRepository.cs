using Ejercicio1.Data;
using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio1.Repositories
{
    // Implementación del repositorio de clientes que interactúa con la base de datos.
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _dbContext;

        public ClienteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtiene un cliente por su ID de manera asincrónica.
        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        // Obtiene todos los clientes de manera asincrónica.
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        // Crea un nuevo cliente de manera asincrónica.
        public async Task CreateAsync(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
        }

        // Actualiza un cliente existente de manera asincrónica.
        public async Task UpdateAsync(Cliente cliente)
        {
            _dbContext.Entry(cliente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Elimina un cliente por su ID de manera asincrónica.
        public async Task DeleteAsync(int id)
        {
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
