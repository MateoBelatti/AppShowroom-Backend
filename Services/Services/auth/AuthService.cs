using biblioteca.dtos.auth;
using biblioteca.Errors;
using Repository;

namespace Services.Services.auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IUsuarioRepository usuarioRepository, IJwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var userVerificar = await _usuarioRepository.FindByEmail(loginDto.Email);
            if (userVerificar is null)
            {
                throw new AppException("Credenciales inválidas", 401, "AuthService.Login");
            }
            if (userVerificar.PasswordHash is null)
            {
                throw new AppException("Este usuario debe iniciar sesión con Google", 401, "AuthService.Login");
            }

            var comparePassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, userVerificar.PasswordHash);
            if (!comparePassword)
            {
                throw new AppException("Credenciales inválidas", 401, "AuthService.Login");
            }

            return _jwtService.generateJwt(userVerificar.Id, userVerificar.Email, userVerificar.Nombre, userVerificar.Rol);
        }
    }

}
