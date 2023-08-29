using ex01.Models;

namespace ex01.Repositories
{
    // Interfaz que define los métodos para interactuar con el repositorio de clientes.
    public interface IClienteRepository
    {
        // Obtiene un cliente por su ID de manera asincrónica.
        Task<Cliente> GetByIdAsync(int id);

        // Obtiene todos los clientes de manera asincrónica.
        Task<IEnumerable<Cliente>> GetAllAsync();

        // Crea un nuevo cliente de manera asincrónica.
        Task CreateAsync(Cliente cliente);

        // Actualiza un cliente existente de manera asincrónica.
        Task UpdateAsync(Cliente cliente);

        // Elimina un cliente por su ID de manera asincrónica.
        Task DeleteAsync(int id);
    }
}
