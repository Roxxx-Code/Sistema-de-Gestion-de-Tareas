using Microsoft.EntityFrameworkCore;
using GestionTareas.Domain.Entities;

namespace GestionTareas.DataAccess.Context;
public class GestionDbContext : DbContext
{
    public GestionDbContext(DbContextOptions<GestionDbContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Nombre).HasMaxLength(100);
            entity.Property(u => u.CorreoElectronico).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Contrasena).IsRequired().HasMaxLength(100);
            entity.Property(u => u.FechaRegistro).IsRequired();
            entity.HasIndex(u => u.CorreoElectronico).IsUnique();
        });
    }
}
