using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.categoria
{
    public class CategoriaUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
