using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace biblioteca.mappers
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<clases.Categoria, dtos.categoria.CategoriaDto>();
            CreateMap<dtos.categoria.CategoriaCreateDto, clases.Categoria>();
            CreateMap<dtos.categoria.CategoriaUpdateDto, clases.Categoria>();
        }
    }
}
