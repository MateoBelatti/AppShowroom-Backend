using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.auth
{
    public interface IAuthGoogleService
    {
        Task<string> LoginWithGoogle(string idToken);
    }
}
