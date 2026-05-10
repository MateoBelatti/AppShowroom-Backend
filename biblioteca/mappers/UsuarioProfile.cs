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
            CreateMap<dtos.usuario.UsuarioCreateDto, clases.Usuario>();
            CreateMap<dtos.usuario.UsuarioUpdateDto, clases.Usuario>();
        }
    }
}
