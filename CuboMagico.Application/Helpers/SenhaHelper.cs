using BCHash = BCrypt.Net.BCrypt;

namespace CuboMagico.Application.Helpers
{
    public class SenhaHelper
    {
        public static string CriarHash(string senha)
            => BCHash.HashPassword(senha);

        public static bool HashValida(string senha, string hash)
            => BCHash.Verify(senha, hash);
    }
}
