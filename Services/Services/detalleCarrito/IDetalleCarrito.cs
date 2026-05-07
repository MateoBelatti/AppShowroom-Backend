using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;

namespace Services.Services.detalleCarrito
{
    public interface IDetalleCarritoService
    {
        public DetalleCarrito create(DetalleCarrito detalleCarrito);
        public DetalleCarrito findAllByIdCarrito(int idCarrito);
        public void delete(int idDetalleCarrito);

    }
}
