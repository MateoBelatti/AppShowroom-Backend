using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace biblioteca.dtos.categoria
{
    public class CategoriaUpdateDto
    {
        [Required(ErrorMessage = "El Id es requerido")]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
