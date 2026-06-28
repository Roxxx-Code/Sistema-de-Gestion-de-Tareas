using GestionTareas.Domain.Enums;

namespace GestionTareas.Domain.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public EstadoTarea Estado { get; set; }
        public PrioridadTarea Prioridad { get; set; }
        
        // Llave foranea
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
