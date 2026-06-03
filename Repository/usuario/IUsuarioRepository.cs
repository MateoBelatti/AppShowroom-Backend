using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;
using biblioteca.types;

namespace Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> GetById(int id);
        Task<Usuario?> FindByEmail(string email);
        Task<IEnumerable<Usuario>> FindByRol(Rol rol);
        Task<Usuario> Create(Usuario entity);
        Task<Usuario> Update(Usuario entity);
        Task Delete(int id);
    }
}
