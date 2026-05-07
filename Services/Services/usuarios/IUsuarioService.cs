using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;

namespace Services.Services.usuarios
{
    public interface IUsuarioService
    {
        public Usuario[] findAll();
        public Usuario findById(int id);
        public Usuario create(Usuario usuario);
        public Usuario update(int id,Usuario data);
        public void delete(int idUsuario);
    }
}
