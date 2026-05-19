using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace biblioteca.clases
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; } = 0;
        public int Stock { get; set; } = 0;
        public bool Activo { get; set; } = true;
        public types.typeProducto Tipo { get; set; } = types.typeProducto.Vela;
        // EF crea tabla intermedia para relacion muchos a muchos entre Producto y Categoria
        public virtual ICollection<Categoria> Categorias { get; set; } = new HashSet<Categoria>();

        public Producto() { }
    }

}
