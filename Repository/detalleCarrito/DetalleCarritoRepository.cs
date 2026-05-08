using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca;
using biblioteca.clases;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class DetalleCarritoRepository : IDetalleCarritoRepository
    {
        public readonly CanelaContext _context;

        public DetalleCarritoRepository(CanelaContext context)
        {
            _context = context;
        }

        public async Task Create(DetalleCarrito entity)
        {
            await _context.DetallesCarrito.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllByCarritoId(int carritoId)
        {
            await _context.DetallesCarrito
                .Where(d => d.CarritoID == carritoId)
                .ExecuteDeleteAsync();
        }

        public async Task<DetalleCarrito[]> FindByCarritoID(int carritoId)
        {
            return await _context.DetallesCarrito
                .Where(d => d.CarritoID == carritoId)
                .ToArrayAsync();
        }

        public async Task<DetalleCarrito?> GetById(int id)
        {
            return await _context.DetallesCarrito.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task Update(DetalleCarrito entity)
        {
            _context.DetallesCarrito.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
