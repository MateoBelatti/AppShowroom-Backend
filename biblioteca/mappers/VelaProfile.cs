using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace biblioteca.mappers
{
    public class VelaProfile : Profile
    {
        public VelaProfile()
        {
            CreateMap<clases.Vela, dtos.vela.VelaDto>();
            CreateMap<dtos.vela.VelaCreateDto, clases.Vela>();
            CreateMap<dtos.vela.VelaUpdateDto, clases.Vela>();
        }
    }
}
