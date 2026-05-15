using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.dtos.auth;

namespace Services.Services.auth
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto loginDto);
    }
}
