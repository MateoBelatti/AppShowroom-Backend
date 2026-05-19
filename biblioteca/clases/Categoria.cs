using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace biblioteca.clases
{
    [Table("Categorias")]
    public class Categoria
    {
        // Propiedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Relacion muchos a muchos con Producto
        public virtual ICollection<Producto> Productos { get; set; } = new HashSet<Producto>();
        // Constructor
        public Categoria() { }
    }
}
