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
        public Task<IEnumerable<UsuarioDto>> GetAll();
        public Task<UsuarioDto?> GetById(int id);
        public Task<UsuarioDto> Create(UsuarioCreateDto usuario);
        public Task<UsuarioDto?> Update(int id,UsuarioUpdateDto data);
        public Task<bool> Delete(int idUsuario);
    }
}
