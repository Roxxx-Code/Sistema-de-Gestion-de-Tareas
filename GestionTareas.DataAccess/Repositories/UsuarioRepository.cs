using Microsoft.EntityFrameworkCore;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces.Repositories;
using GestionTareas.DataAccess.Context;

namespace GestionTareas.DataAccess.Repositories;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    private readonly GestionDbContext _context;
    private readonly DbSet<Usuario> _dbSet;
    public UsuarioRepository(GestionDbContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Usuario>();
    }
    public async Task<Usuario?> GetByCorreoElectronicoAsync(string correoElectronico)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.CorreoElectronico == correoElectronico);
    }
}
