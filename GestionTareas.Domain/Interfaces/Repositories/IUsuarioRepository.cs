using GestionTareas.Domain.Entities;

namespace GestionTareas.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario?> GetByCorreoElectronicoAsync(string correoElectronico);
}
