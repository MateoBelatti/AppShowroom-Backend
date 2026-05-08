using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;
using biblioteca.dtos.detalleCarrito;

namespace Services.Services.detalleCarrito
{
    public interface IDetalleCarritoService
    {
        public void create(DetalleCarritoCreateDto detalleCarrito);
        public List<DetalleCarritoDto> findAllByIdCarrito(int idCarrito);
        public void Update(int idDetalleCarrito, DetalleCarritoUpdateDto detalleCarrito);
        public void delete(int idDetalleCarrito);

    }
}
