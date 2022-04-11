using Service.Interfaces;

namespace Service.Providers;

public class HashProvider : IHashProvider
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public Boolean CompareHash(string hash, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password,hash);
    }
}