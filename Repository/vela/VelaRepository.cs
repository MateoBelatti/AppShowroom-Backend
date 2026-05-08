using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca;
using biblioteca.clases;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class VelaRepository : IVelaRepository
    {
        public readonly CanelaContext _context;

        public VelaRepository(CanelaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vela entity)
        {
            await _context.Velas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Velas
                .Where(v => v.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Vela>> GetAllAsync()
        {
            return await _context.Velas.ToListAsync();
        }

        public async Task<Vela?> GetByIdAsync(int id)
        {
            return await _context.Velas.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task UpdateAsync(Vela entity)
        {
            _context.Velas.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
