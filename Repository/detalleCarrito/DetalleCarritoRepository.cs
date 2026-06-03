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
        private readonly CanelaContext _context;

        public DetalleCarritoRepository(CanelaContext context)
        {
            _context = context;
        }

        public async Task<DetalleCarrito> Create(DetalleCarrito entity)
        {
            var carrito = await _context.DetallesCarrito.AddAsync(entity);
            await _context.SaveChangesAsync();
            return carrito.Entity;
        }

        public async Task DeleteAllByCarritoId(int carritoId)
        {
            await _context.DetallesCarrito
                .Where(d => d.CarritoID == carritoId)
                .ExecuteDeleteAsync();
        }

        public async Task<DetalleCarrito[]> GetByCarritoId(int carritoId)
        {
            return await _context.DetallesCarrito
                .Where(d => d.CarritoID == carritoId)
                .ToArrayAsync();
        }

        public async Task<DetalleCarrito?> GetById(int id)
        {
            return await _context.DetallesCarrito.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DetalleCarrito> Update(DetalleCarrito entity)
        {
            var carrito = _context.DetallesCarrito.Update(entity);
            await _context.SaveChangesAsync();
            return carrito.Entity;
        }
        public async Task Delete(int id)
        {
            DetalleCarrito? detalle = await _context.DetallesCarrito.FindAsync(id);
            if (detalle is null) return;

            await _context.DetallesCarrito.Where(d => d.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }
    }
}
