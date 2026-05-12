using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca;
using biblioteca.clases;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly CanelaContext _context;

        public CategoriaRepository(CanelaContext context)
        {
            _context = context;
        }

        public async Task Create(Categoria entity)
        {
            await _context.Categorias.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Categorias
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }
        public async Task<IEnumerable<Categoria>> GetAllByIds(List<int> ids)
        {
            return await _context.Categorias
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(Categoria entity)
        {
            _context.Categorias.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
