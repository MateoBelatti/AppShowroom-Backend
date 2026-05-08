using biblioteca.clases;
using biblioteca.dtos.vela;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.vela
{
    public interface IVelaService
    {
        public List<VelaDto> findAll();
        public VelaDto findById(int id);
        public bool create(VelaCreateDto vela);
        public bool update(VelaUpdateDto vela);
        public void delete(int idVela);
    }
}
