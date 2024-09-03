using System.Security.Cryptography;
using System.Text;

namespace Core.Helpers.Security.Hasing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public static bool VerifiedPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hmac = new HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
