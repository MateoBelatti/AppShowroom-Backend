using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca;
using biblioteca.clases;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly CanelaContext _context;

        public CarritoRepository(CanelaContext context)
        {
            _context = context;
        }

        public async Task<Carrito> Create(Carrito entity)
        {
            var result = await _context.Carritos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Carrito?> GetByUsuarioId(int usuarioId)
        {
            return await _context.Carritos.FirstOrDefaultAsync(c => c.UsuarioID == usuarioId);
        }

        public async Task<Carrito> Update(Carrito entity)
        {
            var result = _context.Carritos.Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(int id)
        {
            await _context.Carritos
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Carrito>> GetAll()
        {
            return await _context.Carritos.ToListAsync();
        }

        public async Task<Carrito?> GetById(int id)
        {
            return await _context.Carritos.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
