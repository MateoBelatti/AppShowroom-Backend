using biblioteca.dtos.carrito;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.carrito
{
    public interface ICarritoService
    {
        public Task<CarritoDto> findByIdUsuario(int idUsuario);
        public Task<CarritoDto> findById(int id);
        public Task<CarritoDto> create(CarritoCreateDto carrito);
        public Task<CarritoDto> update(int id, CarritoUpdateDto carrito);
        public Task<bool> delete(int idCarrito);
    }
}
