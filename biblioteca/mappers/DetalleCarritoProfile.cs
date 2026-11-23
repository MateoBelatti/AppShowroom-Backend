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
            CreateMap<clases.DetalleCarrito, dtos.detalleCarrito.DetalleCarritoDto>()
                .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Producto != null ? src.Producto.Nombre : string.Empty))
                .ForMember(dest => dest.ImagenProducto, opt => opt.MapFrom(src => src.Producto != null ? src.Producto.Imagen : string.Empty))
                .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.Producto != null ? src.Producto.Precio : 0m))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Producto != null ? src.Producto.Precio * src.Cantidad : 0m));
            CreateMap<dtos.detalleCarrito.DetalleCarritoUpdateDto, clases.DetalleCarrito>();
        }
    }
}
