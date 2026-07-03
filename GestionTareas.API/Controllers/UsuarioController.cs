using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GestionTareas.Domain.Entities;
using GestionTareas.Domain.Interfaces.Services;
using GestionTareas.API.DTOs.Request;
using GestionTareas.API.DTOs.Response;

namespace GestionTareas.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IMapper _mapper;

    public UsuarioController(
        IUsuarioService usuarioService,
        IMapper mapper)
    {
        _usuarioService = usuarioService;
        _mapper = mapper;
    }

    // GET api/usuario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();

        return Ok(_mapper.Map<IEnumerable<UsuarioResponseDTO>>(usuarios));
    }

    // GET api/usuario/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UsuarioResponseDTO>> GetById(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);

        if (usuario == null)
            return NotFound();

        return Ok(_mapper.Map<UsuarioResponseDTO>(usuario));
    }

    // POST api/usuario
    [HttpPost]
    public async Task<ActionResult<UsuarioResponseDTO>> Create(
        UsuarioRequestDTO dto)
    {
        var usuario = _mapper.Map<Usuario>(dto);

        var creado = await _usuarioService.CreateAsync(usuario);

        return CreatedAtAction(
            nameof(GetById),
            new { id = creado.Id },
            _mapper.Map<UsuarioResponseDTO>(creado));
    }

    // PUT api/usuario/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UsuarioRequestDTO dto)
    {
        var usuario = _mapper.Map<Usuario>(dto);

        usuario.Id = id;

        await _usuarioService.UpdateAsync(usuario);

        return NoContent();
    }

    // DELETE api/usuario/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _usuarioService.DeleteAsync(id);

        return NoContent();
    }
}