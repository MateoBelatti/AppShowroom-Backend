using biblioteca.types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace biblioteca.dtos.usuario
{
    public class UsuarioCreateDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }
    }
}
