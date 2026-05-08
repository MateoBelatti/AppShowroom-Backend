using biblioteca.dtos.carrito;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.carrito
{
    public interface ICarritoService
    {
        public CarritoDto findByIdUsuario(int idUsuario);
        public CarritoDto findById(int id);
        public bool create(CarritoCreateDto carrito);
        public bool update(int id, CarritoUpdateDto carrito);
        public void delete(int idCarrito);
    }
}
