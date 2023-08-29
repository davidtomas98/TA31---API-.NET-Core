using ex02.Models;

namespace ex02.Repositories
{
    // Interfaz que define los métodos del repositorio de clientes.
    public interface IClienteRepository
    {
        // Obtener un cliente por su ID de manera asincrónica.
        Task<Cliente> GetByIdAsync(int id);

        // Obtener todos los clientes de manera asincrónica.
        Task<IEnumerable<Cliente>> GetAllAsync();

        // Crear un nuevo cliente de manera asincrónica.
        Task CreateAsync(Cliente cliente);

        // Actualizar un cliente existente de manera asincrónica.
        Task UpdateAsync(Cliente cliente);

        // Eliminar un cliente por su ID de manera asincrónica.
        Task DeleteAsync(int id);
    }
}
