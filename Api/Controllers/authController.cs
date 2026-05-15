using biblioteca.dtos.auth;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services.Services.auth;

[ApiController]
[Route("api/[controller]")]
public class authController : ControllerBase
{
    private readonly IAuthGoogleService _authGoogleService;
    private readonly IAuthService _authService;

    public authController(IAuthGoogleService authGoogleService, IAuthService authService)
    {
        _authGoogleService = authGoogleService;
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _authService.Login(request);
        if (token == null)
        {
            return Unauthorized("Credenciais inválidas");
        }
        return Ok(new { token });
    }
    public record GoogleLoginRequest(string IdToken);
    [HttpPost("google")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
    {
        try
        {
            var token = await _authGoogleService.LoginWithGoogle(request.IdToken);
            return Ok(new { token });
        }
        catch (InvalidJwtException)
        {
            return Unauthorized("Token de Google inválido");
        }
    }
}