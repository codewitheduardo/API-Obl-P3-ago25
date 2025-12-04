namespace Obligatorio.Utilidades
{
    public class Crypto
    {
        public static string HashConBcrypt(string input, int wf)
        {
            return BCrypt.Net.BCrypt.HashPassword(input, wf);
        }

        public static bool VerificarHashBcrypt(string input, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }
    }
}
