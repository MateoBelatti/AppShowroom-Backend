using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;
using biblioteca.dtos.usuario;

namespace Services.Services.usuarios
{
    public interface IUsuarioService
    {
        public List<UsuarioDto> findAll();
        public UsuarioDto findById(int id);
        public bool create(UsuarioCreateDto usuario);
        public bool update(int id,UsuarioUpdateDto data);
        public void delete(int idUsuario);
    }
}
