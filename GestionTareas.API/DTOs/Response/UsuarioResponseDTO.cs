namespace GestionTareas.API.DTOs.Response;

public class UsuarioResponseDTO
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public DateTime FechaRegistro { get; set; }
}
