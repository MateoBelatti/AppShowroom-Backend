using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.detalleCarrito
{
    public class DetalleCarritoDto
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }

        public string NombreProducto { get; set; } = string.Empty;

        public string ImagenProducto { get; set; } = string.Empty;

        public decimal PrecioUnitario { get; set; }

        public int Cantidad { get; set; }

        public decimal Subtotal { get; set; }
    }
}
