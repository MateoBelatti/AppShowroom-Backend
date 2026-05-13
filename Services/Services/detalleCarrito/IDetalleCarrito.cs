using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;
using biblioteca.dtos.carrito;
using biblioteca.dtos.detalleCarrito;

namespace Services.Services.detalleCarrito
{
    public interface IDetalleCarritoService
    {
        public Task<DetalleCarritoDto> create(DetalleCarritoCreateDto detalleCarrito);
        public Task<IEnumerable<DetalleCarritoDto>> findAllByIdCarrito(int idCarrito);
        public Task<DetalleCarritoDto> Update(int idDetalleCarrito, DetalleCarritoUpdateDto detalleCarrito);
        public Task<bool> delete(int idDetalleCarrito);

    }
}
