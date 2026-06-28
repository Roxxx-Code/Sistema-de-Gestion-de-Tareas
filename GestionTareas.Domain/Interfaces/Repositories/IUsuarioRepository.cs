using GestionTareas.Domain.Entities;

namespace GestionTareas.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<Usuario> GetUsuarioByCorreoElectronicoAsync(string correoElectronico);
    Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
    Task AddUsuarioAsync(Usuario usuario);
    Task UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(int id);
}
