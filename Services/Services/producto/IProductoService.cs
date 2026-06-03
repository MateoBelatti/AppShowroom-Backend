using biblioteca.clases;
using biblioteca.dtos.producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.producto
{
    public interface IProductoService
    {
        public Task<IEnumerable<ProductoDto>> GetAll ();
        public Task<IEnumerable<ProductoDto>> GetAllActivos ();
        public Task<ProductoDto?> GetById (int id);
        public Task<IEnumerable<ProductoDto>> GetByCategoria (int idCategoria);
        public Task<ProductoDto> Create(ProductoCreateDto producto);
        public Task<ProductoDto> Update(int idProducto, ProductoUpdateDto producto);
        public Task<bool> Delete (int idProducto);

    }
}
