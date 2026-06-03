using biblioteca.types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace biblioteca.dtos.producto
{
    public class ProductoCreateDto
    {
        [MaxLength(30)]
        public string Nombre { get; set; } = string.Empty;
        [Url]
        public string Imagen { get; set; } = string.Empty;

        public string? Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; } = true;

        public typeProducto Tipo { get; set; }

        public List<int> CategoriasIds { get; set; } = new();
    }
}
