using biblioteca.dtos.detalleCarrito;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.carrito
{
    public class CarritoUpdateDto
    {
        public List<DetalleCarritoUpdateDto> Detalles { get; set; } = new();
    }
}
