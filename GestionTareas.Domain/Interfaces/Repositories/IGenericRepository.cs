using GestionTareas.Domain.Entities;

namespace GestionTareas.Domain.Interfaces.Repositories;

public interface IGenericRepository<U> where U : AuditBase
{
    Task<IEnumerable<U>> GetAllAsync();
    Task<U?> GetByIdAsync(int id);
    Task<U> CreateAsync(U entity);
    //Task<U> AddAsync(U entity);
    Task UpdateAsync(U entity);
    Task DeleteAsync(int id);
}
