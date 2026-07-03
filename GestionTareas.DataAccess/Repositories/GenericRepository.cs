using Microsoft.EntityFrameworkCore;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces.Repositories;
using GestionTareas.DataAccess.Context;

namespace GestionTareas.DataAccess.Repositories;

public class GenericRepository<U> : IGenericRepository<U> where U : AuditBase
{
    private readonly GestionDbContext _context;
    private readonly DbSet<U> _dbSet;
    public GenericRepository(GestionDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<U>();
    }
    public async Task<IEnumerable<U>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<U?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<U> CreateAsync(U entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<U> AddAsync(U entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task UpdateAsync(U entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
