using biblioteca.types;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.usuario
{
    public class UsuarioCreateDto
    {
        public string Nombre { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public Rol Rol { get; set; } = Rol.User;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }
    }
}
