using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.detalleCarrito
{
    public class DetalleCarritoCreateDto
    {
        public int UsuarioId { get; set; }
        public int CarritoID { get; set; }
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }
    }
}
