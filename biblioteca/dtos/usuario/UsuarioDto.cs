using biblioteca.types;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.dtos.usuario
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Rol Rol { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public DateTime? UltimaConeccion { get; set; }
    }
}
