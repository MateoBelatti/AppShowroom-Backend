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
        public Task<DetalleCarritoDto> Create(DetalleCarritoCreateDto detalleCarrito);
        public Task<IEnumerable<DetalleCarritoDto>> GetByCarritoId(int idCarrito);
        public Task<DetalleCarritoDto> Update(DetalleCarritoUpdateDto detalleCarrito);
        public Task<bool> Delete(int idDetalleCarrito);

    }
}
