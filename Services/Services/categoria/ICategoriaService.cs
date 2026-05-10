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
        public Task<bool> create(CategoriaCreateDto data);
        public Task<bool> update(CategoriaUpdateDto data);
        public Task delete(int idCategoria);

    }
}
