using Api.Errors;
using AutoMapper;
using biblioteca.clases;
using biblioteca.dtos.usuario;
using biblioteca.types;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            IMapper mapper
            )
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<UsuarioDto> create(UsuarioCreateDto usuario)
        {
            var userVerificar = await _usuarioRepository.FindByEmail(usuario.Email);
            if (userVerificar != null)
            {
                throw new AppException("El correo electrónico ya está en uso", 400, "UsuarioService.create");
            }
            var newUsuario = _mapper.Map<Usuario>(usuario);
            newUsuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuario.Password); // hash de la contraseña
            newUsuario.Rol = Rol.User; // Por defecto, el rol es Usuario
            var usuarioCreado = await _usuarioRepository.Create(newUsuario);
            return _mapper.Map<UsuarioDto>(usuarioCreado);
        }

        public async Task<bool> delete(int idUsuario)
        {
            var usuarioExistente = await _usuarioRepository.FindById(idUsuario);
            if (usuarioExistente is null)
            {
                return false;   
            }
            await _usuarioRepository.Delete(idUsuario);
            return true;
        }

        public async Task<IEnumerable<UsuarioDto>> findAll()
        {
            var usuarios = await _usuarioRepository.GetAll();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto?> findById(int id)
        {
            var usuario = await _usuarioRepository.FindById(id);
            if (usuario is null) return null;
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto?> update(int id, UsuarioUpdateDto data)
        {
            var usuarioExistente = await _usuarioRepository.FindById(id);
            if (usuarioExistente is null) 
            {
                throw new AppException("Usuario no encontrado", 404, "UsuarioService.update");
            }
            _mapper.Map(data, usuarioExistente);
            var usuarioActualizado = await _usuarioRepository.Update(usuarioExistente);
            return _mapper.Map<UsuarioDto>(usuarioActualizado);
        }
    }
}
