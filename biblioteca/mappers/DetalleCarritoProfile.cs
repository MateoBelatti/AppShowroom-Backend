using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace biblioteca.mappers
{
    public class DetalleCarritoProfile : Profile
    {
        public DetalleCarritoProfile()
        {
            CreateMap<clases.DetalleCarrito, dtos.detalleCarrito.DetalleCarritoDto>();
            CreateMap<dtos.detalleCarrito.DetalleCarritoCreateDto, clases.DetalleCarrito>();
            CreateMap<dtos.detalleCarrito.DetalleCarritoUpdateDto, clases.DetalleCarrito>();
        }
    }
}
