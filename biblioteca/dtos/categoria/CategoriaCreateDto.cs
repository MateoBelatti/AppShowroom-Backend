using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace biblioteca.dtos.categoria
{
    public class CategoriaCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        public string Nombre { get; set; } = string.Empty;
    }
}
