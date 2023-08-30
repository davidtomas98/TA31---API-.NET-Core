using Ejercicio2.Data;
using Ejercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio2.Repositories
{
    // Implementación del repositorio de clientes.
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _dbContext;

        public ClienteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Obtener un cliente por su ID.
        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        // Obtener todos los clientes.
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        // Crear un nuevo cliente.
        public async Task CreateAsync(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
        }

        // Actualizar un cliente existente.
        public async Task UpdateAsync(Cliente cliente)
        {
            _dbContext.Entry(cliente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        // Eliminar un cliente por su ID.
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
