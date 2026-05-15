using biblioteca.types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.auth
{
    public interface IJwtService
    {
        string generateJwt(int userId, string email, string name, Rol rol);
    }
}
