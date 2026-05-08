using biblioteca.dtos.detalleCarrito;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.carrito
{
    public class CarritoDto
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime UltimaVez { get; set; }

        public List<DetalleCarritoDto> Detalles { get; set; } = new();
    }
}
