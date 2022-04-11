using Model;
using Service.Validations;

namespace Service.Interfaces;

public interface IUserServiceCollection
{
    User SignUp(Validations.Validations props);
    string SignIn(ValidateUserSignIn props);
    User? FindUserByUserName(string username);
}