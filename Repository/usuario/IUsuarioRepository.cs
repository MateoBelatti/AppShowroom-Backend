using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> FindById(int id);
        Task<Usuario?> FindByEmail(string email);
        Task<IEnumerable<Usuario>> FindByRol(string rol);
        Task<Usuario> Create(Usuario entity);
        Task<Usuario?> Update(Usuario entity);
        Task Delete(int id);
    }
}
