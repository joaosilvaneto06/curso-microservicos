using Infra.Repositories.Interfaces;
using Model;
using Service.Interfaces;
using Api.Errors;
using Service.Validations;
namespace Service.Services;
public class UserServiceCollection : IUserServiceCollection
{
    private readonly IUserRepository _userRepository;
    private readonly IHashProvider _hashProvider;
    private readonly ITokenProvider _tokenProvider;
    public UserServiceCollection(IUserRepository userRepository, IHashProvider hashProvider, ITokenProvider tokenProvider)
    {
        _userRepository = userRepository;
        _hashProvider = hashProvider;
        _tokenProvider = tokenProvider;
    }
    
    public User? FindUserByUserName(string username)
    {
        return _userRepository.FindByUsername(username);

    }

    public User SignUp(Validations.Validations props)
    {
        props.Validate();
        if(FindUserByUserName(props.name) != null)
        {
            throw new AppError("Username já utilizado",400);
        }

        //Hash
        var hashedpassowrd = _hashProvider.HashPassword(props.password);

        var user = new User 
        { 
            id = Guid.NewGuid(),
            username = props.username,
            password = hashedpassowrd,
            name = props.name,
        };
        _userRepository.Create(user);
        return user;
    }

    public string SignIn(ValidateUserSignIn props)
    {
        props.Validate();

        var user = FindUserByUserName(props.username);
        if (user == null)
            throw new AppError("Usuario ou senha invalidos",400);
        
        var isPasswordValid = _hashProvider.CompareHash(user.password, props.password);

        if(!isPasswordValid)
            throw new AppError("Usuario ou senha invalidos",400);
        
        var token = _tokenProvider.Generate(user);

        return token;     
    }
}