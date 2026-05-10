using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace biblioteca.mappers
{
    public class CarritoProfile : Profile
    {
        public CarritoProfile()
        {
            CreateMap<clases.Carrito, dtos.carrito.CarritoDto>();
            CreateMap<dtos.carrito.CarritoCreateDto, clases.Carrito>();
            CreateMap<dtos.carrito.CarritoUpdateDto, clases.Carrito>();
        }
    }
}
