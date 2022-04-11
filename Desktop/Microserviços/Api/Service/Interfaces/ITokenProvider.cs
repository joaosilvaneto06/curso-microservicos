using Model;

namespace Service.Interfaces;

public interface ITokenProvider
{
    string Generate(User user);
}