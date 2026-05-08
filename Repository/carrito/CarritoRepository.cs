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
        public readonly CanelaContext _context;

        public CarritoRepository(CanelaContext context)
        {
            _context = context;
        }

        public async Task Create(Carrito entity)
        {
            await _context.Carritos.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Carritos
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Carrito>> GetAllA()
        {
            return await _context.Carritos.ToListAsync();
        }

        public async Task<Carrito?> GetById(int id)
        {
            return await _context.Carritos.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
