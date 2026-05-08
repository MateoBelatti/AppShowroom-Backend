using biblioteca.clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.vela
{
    public interface IVelaService
    {
        public Vela[] findAll();
        public Vela findById(int id);
        public Vela create(Vela vela);
        public Vela update(Vela vela);
        public void delete(int idVela);
    }
}
