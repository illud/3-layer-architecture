using BC = BCrypt.Net.BCrypt;

namespace Business_Logic_Layer.Services
{
    internal class BcryptService
    {
        public string HashPassword(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            bool verify = BC.Verify(password, passwordHash);

            return verify;
        }
    }
}
