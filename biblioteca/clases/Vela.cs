using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace biblioteca.clases
{
    [Table("Velas")]
    public class Vela : Producto
    {
        public decimal? CantidadCl { get; set; }
        public string Aroma { get; set; } = string.Empty;

        // Contructores
        public Vela() { }
    }
}
