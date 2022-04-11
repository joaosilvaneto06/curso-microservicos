using Api.Errors;
using Service.Interfaces;
using Service.Validations;

namespace Api.Routes;

public static class AppRoutes
{
    public static void ConfigureRoutes(this WebApplication app)
    {
        app.MapPost("/sign-up", SignUp);
        app.MapPost("/signin", SignIn);
    }

    private static IResult SignUp(IUserServiceCollection userService, Validations props)
    {
         try
        {
            var user = userService.SignUp(props);
            return Results.Ok(user);
        }
        catch (AppError ex)
        {
            return Results.Problem(statusCode: ex.statusCode, detail: ex.message);
        }
        catch
        {
            return Results.Problem(statusCode:500, detail: "Internal Server Error");
        }   
    }

    private static IResult SignIn(IUserServiceCollection userService, ValidateUserSignIn props)
    {
        try
        {
            var token = userService.SignIn(props);
            return Results.Ok(token);
        }
        catch (AppError ex)
        {
            return Results.Problem(statusCode: ex.statusCode, detail: ex.message);
        }
        catch
        {
            return Results.Problem(statusCode:500, detail: "Internal Server Error");
        }   
    }

}