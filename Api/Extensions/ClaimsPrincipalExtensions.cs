using Api.Errors;
using System.Security.Claims;

namespace Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUsuarioId(this ClaimsPrincipal user)
        {
            var valor = user.FindFirstValue("id");
            if (string.IsNullOrWhiteSpace(valor) || !int.TryParse(valor, out var id))
            {
                throw new AppException("No se pudo identificar al usuario autenticado.", 401, "ClaimsPrincipalExtensions.GetUsuarioId");
            }

            return id;
        }
    }
}
