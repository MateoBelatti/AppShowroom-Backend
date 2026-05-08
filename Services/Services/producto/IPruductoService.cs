using biblioteca.clases;
using biblioteca.dtos.producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.producto
{
    public interface IProductoService
    {
        public List<ProductoDto> findAll ();
        public ProductoDto findById (int id);
        public List<ProductoDto> findByCategoria (int idCategoria);
        public bool create(ProductoCreateDto producto);
        public bool update(ProductoUpdateDto producto);
        public void delete (int idProducto);

    }
}
