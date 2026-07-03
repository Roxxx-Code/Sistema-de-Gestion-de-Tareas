namespace GestionTareas.API.DTOs.Request;

public class UsuarioRequestDTO
{
    public string? Nombre { get; set; }
    public string CorreoElectronico { get; set; }
    public string Contrasena { get; set; }
    //public DateTime FechaRegistro { get; set; }
}
