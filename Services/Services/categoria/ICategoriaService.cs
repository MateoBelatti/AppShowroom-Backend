using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;

namespace Services.Services.categoria
{
    public interface ICategoriaService
    {
        public Categoria[] findAll();
        public Categoria findById(int id);
        public Categoria create(Categoria data);
        public Categoria update(Categoria data);
        public void delete(int idCategoria);

    }
}
