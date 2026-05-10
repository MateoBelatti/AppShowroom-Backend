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
        public Task<ProductoDto> findById (int id);
        public Task<List<ProductoDto>> findByCategoria (int idCategoria);
        public Task<bool> create(ProductoCreateDto producto);
        public Task<bool> update(ProductoUpdateDto producto);
        public Task delete (int idProducto);

    }
}
