using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace biblioteca.clases
{
    [Table("Carritos")]
    public class Carrito
    {
        // Propiedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaVez { get; set; }

        // 
        [ForeignKey("UsuarioID")]
        public virtual Usuario? Usuario { get; set; }

        // Collecciones
        public virtual ICollection<DetalleCarrito> Detalles { get; set; } = new HashSet<DetalleCarrito>();

        // Contructores
        public Carrito() { }
    }
}
