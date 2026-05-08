using biblioteca.dtos.producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.vela
{
    public class VelaCreateDto : ProductoCreateDto
    {
        public decimal? CantidadCl { get; set; }
        public string Aroma { get; set; } = string.Empty;
    }
}
