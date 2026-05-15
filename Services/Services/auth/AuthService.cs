using Api.Errors;
using biblioteca.dtos.auth;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;
        public AuthService(IConfiguration configuration, IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            var userVerificar = await _usuarioRepository.FindByEmail(loginDto.Email);
            if (userVerificar is null)
            {
                throw new AppException("Usuario no encontrado", 404, "AuthService.Login");
            }
            if (userVerificar.PasswordHash is null)
            {
                throw new AppException("Este usuario requiere login con Google", 400, "AuthService.login");
            }
            var comparePassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, userVerificar.PasswordHash);
            if (!comparePassword)
            {
                throw new AppException("Contraseña usuario o contraseña incorrecta", 400, "AuthService.Login");
            }
            return _jwtService.generateJwt(userVerificar.Id, userVerificar.Email, userVerificar.Nombre, userVerificar.Rol);
        }
    }

}
