namespace Model;

public record CreateUser
{
    public string username { get; init; } = default!;
    public string password { get; init; } = default!;
    public string name { get; init; } = default!;
}