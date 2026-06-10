using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace biblioteca
{
    public class CanelaContext : DbContext
    {
        public CanelaContext(DbContextOptions<CanelaContext> options) : base(options) { }
        public DbSet<clases.Vela> Velas { get; set; }
        public DbSet<clases.Categoria> Categorias { get; set; }
        public DbSet<clases.Usuario> Usuarios { get; set; }
        public DbSet<clases.Producto> Productos { get; set; }
        public DbSet<clases.Carrito> Carritos { get; set; }
        public DbSet<clases.DetalleCarrito> DetallesCarrito { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de clase abstracta
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<clases.Producto>().UseTpcMappingStrategy();

        }
    }
}
