using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;
using biblioteca.dtos.categoria;

namespace Services.Services.categoria
{
    public interface ICategoriaService
    {
        public List<CategoriaDto> findAll();
        public CategoriaDto findById(int id);
        public bool create(CategoriaCreateDto data);
        public bool update(CategoriaUpdateDto data);
        public void delete(int idCategoria);

    }
}
