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
        public Task<IEnumerable<CategoriaDto>> GetAll();
        public Task<CategoriaDto> GetById(int id);
        public Task<CategoriaDto> Create(CategoriaCreateDto data);
        public Task<CategoriaDto> Update(int id, CategoriaUpdateDto data);
        public Task<bool> Delete(int idCategoria);

    }
}
