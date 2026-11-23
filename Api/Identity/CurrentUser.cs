using Api.Extensions;
using biblioteca.Errors;
using Services;

namespace Api.Identity
{
    public sealed class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UsuarioId =>
            _httpContextAccessor.HttpContext?.User.GetUsuarioId()
            ?? throw new AppException("No se pudo identificar al usuario autenticado.", 401, "CurrentUser.UsuarioId");

        public bool EsAdmin =>
            _httpContextAccessor.HttpContext?.User.IsInRole("Admin") ?? false;
    }
}
