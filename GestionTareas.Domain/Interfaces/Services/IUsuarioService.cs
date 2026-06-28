using GestionTareas.Domain.Entities;

namespace GestionTareas.Domain.Interfaces.Services;

public interface IUsuarioService
{
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<Usuario> GetUsuarioByCorreoElectronicoAsync(string correoElectronico);
    Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    Task<Usuario> CreatedAsync (Usuario usuario);
    Task AddUsuarioAsync(Usuario usuario);
    Task UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(int id);
}
