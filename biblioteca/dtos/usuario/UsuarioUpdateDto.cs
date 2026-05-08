using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.usuario
{
    public class UsuarioUpdateDto
    {
        public string Nombre { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }
    }
}
