using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class HandlePassword
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 10);

        }

        public static bool verifyPassword(string passwordPlain, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(passwordPlain, hashPassword);

        }
    }
}
