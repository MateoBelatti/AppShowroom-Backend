using biblioteca.clases;
using biblioteca.types;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Services.auth
{
    public class AuthGoogleService : IAuthGoogleService
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtService _jwtService;

        public AuthGoogleService(IConfiguration config, IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            _config = config;
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        public async Task<string> LoginWithGoogle(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _config["Google:ClientId"] }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var usuario = await _usuarioRepository.FindByEmail(payload.Email);
            if (usuario is null)
            {
                usuario = await _usuarioRepository.Create(new Usuario
                {
                    Email = payload.Email,
                    Nombre = payload.Name,
                    Rol = Rol.User
                });
            }

            return _jwtService.generateJwt(usuario.Id, usuario.Email, usuario.Nombre, usuario.Rol);
        }
    }
}