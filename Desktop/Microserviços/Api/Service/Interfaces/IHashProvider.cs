namespace Service.Interfaces;

public interface IHashProvider
{
    string HashPassword(string password);
    Boolean CompareHash(string hash, string password);
}