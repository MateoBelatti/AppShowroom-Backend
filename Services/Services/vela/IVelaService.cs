using biblioteca.clases;
using biblioteca.dtos.vela;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.vela
{
    public interface IVelaService
    {
        public Task<IEnumerable<VelaDto>> findAll();
        public Task<VelaDto> findById(int id);
        public Task<bool> create(VelaCreateDto vela);
        public Task<bool> update(VelaUpdateDto vela);
        public Task delete(int idVela);
    }
}
