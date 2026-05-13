using biblioteca.clases;
using biblioteca.dtos.producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.producto
{
    public interface IProductoService
    {
        public Task<IEnumerable<ProductoDto>> findAll ();
        public Task<IEnumerable<ProductoDto>> findAllActivos ();
        public Task<ProductoDto?> findById (int id);
        public Task<IEnumerable<ProductoDto>> findByCategoria (int idCategoria);
        public Task<ProductoDto> create(ProductoCreateDto producto);
        public Task<ProductoDto> update(int idProducto, ProductoUpdateDto producto);
        public Task<bool> delete (int idProducto);

    }
}
