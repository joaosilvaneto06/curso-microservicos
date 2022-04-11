using System.Text.Json.Serialization;

namespace Model;

public record User
{
    public Guid id { get; init; }
    public string username { get; init; } = default!;
    public string name { get; init; } = default!;
    [JsonIgnore]
    public string password { get; init; } = default!;
    public Boolean isAdmin { get; init; }
}