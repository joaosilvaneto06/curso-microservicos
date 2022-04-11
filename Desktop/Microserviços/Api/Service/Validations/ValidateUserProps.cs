using Api.Errors;
using Flunt.Notifications;
using Flunt.Validations;

namespace Service.Validations;

public class Validations : Notifiable<Notification>
{
    public string username { get; init; } = default!;
    public string password { get; init; } = default!;
    public string name { get; init; } = default!;

    public void MapTo()
    {
        var contract = new Contract<Notification>()
        .Requires()
        .IsNotNullOrEmpty(username, "Informe um login válido.")
        .IsGreaterThan(username, 4, "Login deve ter no mínimo 5 digitos.")
        .IsNotNullOrEmpty(password, "Informe um password válido.")
        .IsGreaterThan(password, 7, "Password deve ter no mínimo 8 digitos.")
        .IsNotNullOrEmpty(name, "Informe um nome válido.")
        .IsGreaterThan(name, 2, "Nome deve ter no mínimo 2 digitos.");

        AddNotifications(contract);
    }

    public void Validate()
    {
        MapTo();
        if(!IsValid)
        {
            var message = Notifications.First().Key;

            throw new AppError(message, 400);
        }
    }


}
