using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca;
using biblioteca.clases;
using biblioteca.types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly CanelaContext _context;

        public UsuarioRepository(CanelaContext context)
        {
            _context = context;
        }
        public async Task Create(Usuario entity)
        {
            await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Usuarios
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }

        public Task<Usuario?> FindByEmail(string email)
        {
            return _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<Usuario?> FindById(int id)
        {
            return _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<IEnumerable<Usuario>> FindByRol(Rol rol)
        {
            return _context.Usuarios
                .Where(u => u.Rol == rol)
                .ToListAsync()
                .ContinueWith(t => (IEnumerable<Usuario>)t.Result);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios
                .ToListAsync();
        }

        public async Task Update(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
