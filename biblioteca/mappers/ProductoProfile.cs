using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace biblioteca.mappers
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<clases.Categoria, dtos.categoria.CategoriaDto>();

            CreateMap<clases.Producto, dtos.producto.ProductoDto>();
            CreateMap<dtos.producto.ProductoCreateDto, clases.Producto>();
            CreateMap<dtos.producto.ProductoUpdateDto, clases.Producto>();
        }
    }
}
