
namespace OlxMax.Dal.Security
{
    public class PasswordHasher
    {
        private const int WorkFactor = 12;

        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(WorkFactor);

            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
