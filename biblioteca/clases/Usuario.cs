using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using System.Text;

namespace biblioteca.clases
{
    [Table("Usuarios")]
    public class Usuario
    {
        // Propiedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PasswordHash { get; set; } // nullable para usuarios de google
        public types.Rol Rol { get; set; } = types.Rol.User;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime? UltimaConeccion { get; set; }
        // Contructores
        public Usuario() { }

    }
}
