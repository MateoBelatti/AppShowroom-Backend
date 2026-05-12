using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca;
using biblioteca.clases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly CanelaContext _context;

        public ProductoRepository(CanelaContext context)
        {
            _context = context;
        }
        public async Task<Producto> Create(Producto entity)
        {
            var producto = await _context.Productos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return producto.Entity;
        }

        public async Task Delete(int id)
        {
            Producto? producto = await _context.Productos.FindAsync(id);
            if (producto is null) return;

            producto.Activo = false;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _context.Productos
                .Include(p => p.Categorias)
                .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetAllActivos()
        {
            // Devuelve todos los productos activos de la base de datos
            return await _context.Productos
                .Where(p => p.Activo == true)
                .Include(p => p.Categorias)
                .ToListAsync();
        }

        public async Task<Producto?> GetById(int id)
        {
            return await _context.Productos
                .Include(p => p.Categorias)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Producto> Update(Producto entity)
        {
            var productoUpdate = _context.Productos.Update(entity);
            await _context.SaveChangesAsync();
            return productoUpdate.Entity;
        }

        public async Task<bool> UpdateActivos(int productoId, int cantidad)
        {
            Producto?  producto = await _context.Productos.FindAsync(productoId);
            if (producto == null || producto.Stock < cantidad)
                return false;

            producto.Stock -= cantidad;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
