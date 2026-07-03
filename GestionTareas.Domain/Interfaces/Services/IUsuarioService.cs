using GestionTareas.Domain.Entities;

namespace GestionTareas.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario> CreateAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(int id);
    Task<Usuario?> GetUsuarioByCorreoElectronicoAsync(string correoElectronico);
}
