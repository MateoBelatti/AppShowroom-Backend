using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository.clases
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<Usuario> Create(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> FindByRol(string rol)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
