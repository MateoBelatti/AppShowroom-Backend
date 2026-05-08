using biblioteca.types;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.producto
{
    public abstract class ProductoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Imagen { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; }

        public typeProducto Tipo { get; set; }

        public List<int> CategoriasIds { get; set; } = new();
    }
}
