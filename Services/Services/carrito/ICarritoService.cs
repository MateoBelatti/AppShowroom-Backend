using biblioteca.dtos.carrito;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.carrito
{
    public interface ICarritoService
    {
        public Task<CarritoDto> findByIdUsuario(int idUsuario, int idUsuarioActual);
        public Task<CarritoDto> findById(int id, int idUsuarioActual);
        public Task<CarritoDto> create(int idUsuarioActual);
        public Task<CarritoDto> update(int id, CarritoUpdateDto carrito, int idUsuarioActual);
        public Task<bool> delete(int idCarrito, int idUsuarioActual);
    }
}
