using Model;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Interfaces;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _databaseContext;
    private DbSet<User> entity;

    public UserRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        entity = databaseContext.Set<User>();
    }
    public void Create(User user)
    {
        entity.Add(user);
        _databaseContext.SaveChanges();
    }

    public User? FindByUsername(string username)
    {
        return entity.SingleOrDefault(x => x.username == username);
    }

    public void SaveChanges()
    {
        _databaseContext.SaveChanges();
    }
}