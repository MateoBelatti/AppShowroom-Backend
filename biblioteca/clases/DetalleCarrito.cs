using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace biblioteca.clases
{
    [Table("DetalleCarrito")]
    public class DetalleCarrito
    {
        // Propiedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CarritoID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("CarritoID")]
        public virtual Carrito? Carrito { get; set; }

        [ForeignKey("ProductoID")]
        public virtual Producto? Producto { get; set; }

        // Contructores
        public DetalleCarrito() { }
    }
}
