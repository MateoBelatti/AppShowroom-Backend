using biblioteca.dtos.carrito;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.carrito
{
    public interface ICarritoService
    {
        public Task<CarritoDto> GetByUsuarioId(int idUsuario);
        public Task<CarritoDto> GetById(int id);
        public Task<CarritoDto> Create(CarritoCreateDto carrito);
        public Task<CarritoDto> Update(int id, CarritoUpdateDto carrito);
        public Task<bool> Delete(int idCarrito);
    }
}
