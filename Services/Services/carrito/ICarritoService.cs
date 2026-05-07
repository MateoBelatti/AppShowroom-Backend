using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;

namespace Services.Services.carrito
{
    public interface ICarritoService
    {
        public Carrito findByIdUsuario(int idUsuario);
        public Carrito findById(int id);
        public Carrito create(Carrito carrito);
        public Carrito update(int id, Carrito carrito);
        public void delete(int idCarrito);
    }
}
