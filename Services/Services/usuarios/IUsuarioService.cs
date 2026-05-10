using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.clases;
using biblioteca.dtos.usuario;
using System.Threading.Tasks;

namespace Services.Services.usuarios
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<UsuarioDto>> findAll();
        public Task<UsuarioDto> findById(int id);
        public Task<bool> create(UsuarioCreateDto usuario);
        public Task<bool> update(int id,UsuarioUpdateDto data);
        public Task delete(int idUsuario);
    }
}
