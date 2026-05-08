using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository.clases
{
    public class VelaRepository : IVelaRepository
    {
        public async Task<IEnumerable<Vela>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Vela?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Vela entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Vela entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
