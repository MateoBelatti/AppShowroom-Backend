using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository.clases
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public Task Create(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Categoria?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
