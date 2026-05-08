using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public class ProductoRepository : IProductoRepository
    {
        public Task Create(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> GetAllActivos()
        {
            throw new NotImplementedException();
        }

        public Task<Producto?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateActivos(int productoId, int cantidad)
        {
            throw new NotImplementedException();
        }
    }
}
