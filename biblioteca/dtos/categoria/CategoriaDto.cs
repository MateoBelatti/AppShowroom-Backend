using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace biblioteca.dtos.categoria
{
    public class CategoriaDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
    }
}
