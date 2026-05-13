using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria?> GetById(int id);
        Task<Categoria> Create(Categoria entity);
        Task<Categoria> Update(Categoria entity);
        Task Delete(int id);
        Task<IEnumerable<Categoria>> GetAllByIds(List<int> ids);
    }
}
