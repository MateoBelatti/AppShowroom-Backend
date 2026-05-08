using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public class CarritoRepository : ICarritoRepository
    {
        public Task Create(Carrito entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Carrito>> GetAllA()
        {
            throw new NotImplementedException();
        }

        public Task<Carrito?> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
