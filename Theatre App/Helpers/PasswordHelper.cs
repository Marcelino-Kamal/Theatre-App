using Microsoft.AspNetCore.Identity;

namespace Theatre_App.Helpers
{
    public class PasswordHelper
    {

        private static readonly PasswordHasher<object> _hasher = new();

        
        public static string HashPassword(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        
        public static bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
