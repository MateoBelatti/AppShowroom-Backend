using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace biblioteca.dtos.detalleCarrito
{
    public class DetalleCarritoUpdateDto
    {
        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }
        public int Cantidad { get; set; }
    }
}
