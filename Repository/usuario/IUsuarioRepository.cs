using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;
using biblioteca.types;

namespace Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario?> FindById(int id);
        Task<Usuario?> FindByEmail(string email);
        Task<IEnumerable<Usuario>> FindByRol(Rol rol);
        Task Create(Usuario entity);
        Task Update(Usuario entity);
        Task Delete(int id);
    }
}
