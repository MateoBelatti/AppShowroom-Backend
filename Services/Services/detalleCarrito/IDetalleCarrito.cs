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
        public Task<DetalleCarritoDto> create(DetalleCarritoCreateDto detalleCarrito, int idUsuarioActual);
        public Task<IEnumerable<DetalleCarritoDto>> findAllByIdCarrito(int idCarrito, int idUsuarioActual);
        public Task<DetalleCarritoDto> Update(DetalleCarritoUpdateDto detalleCarrito, int idUsuarioActual);
        public Task<bool> delete(int idDetalleCarrito, int idUsuarioActual);

    }
}
