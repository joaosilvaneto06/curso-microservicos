using Model;
using Microsoft.EntityFrameworkCore;
namespace Infra.Context;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"DataSource=app.db;Cache=Shared");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.id);
        modelBuilder.Entity<User>().Property(user => user.isAdmin).HasDefaultValue(false);
        modelBuilder.Entity<User>().HasIndex(user => user.id).IsUnique();
    }
    public DbSet<User> Users { get; set; } = default!;
}