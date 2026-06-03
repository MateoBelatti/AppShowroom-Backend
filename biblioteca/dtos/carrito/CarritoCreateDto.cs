using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace biblioteca.dtos.carrito
{
    public class CarritoCreateDto
    {
        [Required]
        public int UsuarioId { get; set; }
    }
}
