using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;
using biblioteca.dtos.categoria;
using System.Threading.Tasks;

namespace Services.Services.categoria
{
    public interface ICategoriaService
    {
        public Task<IEnumerable<CategoriaDto>> findAll();
        public Task<CategoriaDto> findById(int id);
        public Task<CategoriaDto> create(CategoriaCreateDto data);
        public Task<CategoriaDto> update(int idCat, CategoriaUpdateDto data);
        public Task<bool> delete(int idCategoria);

    }
}
