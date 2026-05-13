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
        private readonly CanelaContext _context;

        public UsuarioRepository(CanelaContext context)
        {
            _context = context;
        }
        public async Task<Usuario> Create(Usuario entity)
        {
            var usuario = await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();
            return usuario.Entity;
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

        public async Task<IEnumerable<Usuario>> FindByRol(Rol rol)
        {
            return await _context.Usuarios
                .Where(u => u.Rol == rol)
                .ToListAsync(); 
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios
                .ToListAsync();
        }

        public async Task<Usuario> Update(Usuario entity)
        {
            var usuario = _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
            return usuario.Entity;
        }
    }
}
