using biblioteca.clases;
using biblioteca.dtos.vela;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.vela
{
    public class VelaService : IVelaService
    {
        public Task<bool> create(VelaCreateDto vela)
        {
            throw new NotImplementedException();
        }

        public Task delete(int idVela)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VelaDto>> findAll()
        {
            throw new NotImplementedException();
        }

        public Task<VelaDto> findById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> update(VelaUpdateDto vela)
        {
            throw new NotImplementedException();
        }
    }
}
