using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository.clases
{
    public class DetalleCarritoRepository : IDetalleCarritoRepository
    {
        public Task Create(DetalleCarrito entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllByCarritoId(int carritoId)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleCarrito[]> FindByCarritoID(int carritoId)
        {
            throw new NotImplementedException();
        }

        public Task<DetalleCarrito?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(DetalleCarrito entity)
        {
            throw new NotImplementedException();
        }
    }
}
