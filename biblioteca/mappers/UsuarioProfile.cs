using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace biblioteca.mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<clases.Usuario, dtos.usuario.UsuarioDto>();
            // mappeo de usuarioDto a Usuario, ignorando el password hash y el rol (se manejan del service)
            CreateMap<dtos.usuario.UsuarioCreateDto, clases.Usuario>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Rol, opt => opt.Ignore());
            CreateMap<dtos.usuario.UsuarioUpdateDto, clases.Usuario>();
        }
    }
}
