using AutoMapper;
using GestionTareas.Domain.Entities;
using GestionTareas.API.DTOs.Request;
using GestionTareas.API.DTOs.Response;

namespace GestionTareas.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UsuarioResponseDTO>();
        CreateMap<UsuarioRequestDTO, Usuario>();
    }
}
