using Microsoft.Extensions.Logging;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces.Repositories;
using GestionTareas.Domain.Interfaces.Services;

namespace GestionTareas.Domain.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(
        IUsuarioRepository usuarioRepository,
        ILogger<UsuarioService> logger)
    {
        _usuarioRepository = usuarioRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        _logger.LogInformation("Consultando todos los usuarios.");

        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("El id del usuario es inválido.");

        var usuario = await _usuarioRepository.GetByIdAsync(id);

        if (usuario == null)
            _logger.LogWarning("No se encontró el usuario con Id {Id}.", id);

        return usuario;
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        ValidarUsuario(usuario);

        usuario.CorreoElectronico = usuario.CorreoElectronico.Trim().ToLower();

        var usuarioExistente =
            await _usuarioRepository.GetByCorreoElectronicoAsync(usuario.CorreoElectronico);

        if (usuarioExistente != null)
            throw new InvalidOperationException("Ya existe un usuario con ese correo electrónico.");

        _logger.LogInformation(
            "Creando usuario con correo {Correo}.",
            usuario.CorreoElectronico);

        return await _usuarioRepository.CreateAsync(usuario);
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        ValidarUsuario(usuario);

        var usuarioActual = await _usuarioRepository.GetByIdAsync(usuario.Id);

        if (usuarioActual == null)
            throw new KeyNotFoundException("El usuario no existe.");

        usuario.CorreoElectronico = usuario.CorreoElectronico.Trim().ToLower();

        var usuarioCorreo =
            await _usuarioRepository.GetByCorreoElectronicoAsync(usuario.CorreoElectronico);

        if (usuarioCorreo != null && usuarioCorreo.Id != usuario.Id)
            throw new InvalidOperationException("El correo electrónico ya está registrado.");

        _logger.LogInformation(
            "Actualizando usuario con Id {Id}.",
            usuario.Id);

        await _usuarioRepository.UpdateAsync(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
            throw new ArgumentException("El id del usuario es inválido.");

        var usuario = await _usuarioRepository.GetByIdAsync(id);

        if (usuario == null)
            throw new KeyNotFoundException("El usuario no existe.");

        _logger.LogInformation(
            "Eliminando usuario con Id {Id}.",
            id);

        await _usuarioRepository.DeleteAsync(id);
    }

    public async Task<Usuario?> GetUsuarioByCorreoElectronicoAsync(string correoElectronico)
    {
        if (string.IsNullOrWhiteSpace(correoElectronico))
            throw new ArgumentException("El correo electrónico es obligatorio.");

        correoElectronico = correoElectronico.Trim().ToLower();

        return await _usuarioRepository
            .GetByCorreoElectronicoAsync(correoElectronico);
    }

    private static void ValidarUsuario(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        if (string.IsNullOrWhiteSpace(usuario.Nombre))
            throw new ArgumentException("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(usuario.CorreoElectronico))
            throw new ArgumentException("El correo electrónico es obligatorio.");

        if (!usuario.CorreoElectronico.Contains("@"))
            throw new ArgumentException("El correo electrónico no es válido.");
    }
}