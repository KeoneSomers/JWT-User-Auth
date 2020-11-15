using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Test
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
