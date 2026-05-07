using biblioteca.clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.producto
{
    public interface IProductoService
    {
        public Producto[] findAll ();
        public Producto findById (int id);
        public Producto[] findByCategoria (int idCategoria);
        public Producto create(Producto producto);
        public Producto update(Producto producto);
        public void delete (int idProducto);

    }
}
