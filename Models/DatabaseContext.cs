using Microsoft.EntityFrameworkCore;

namespace MyApp.Models;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options)
      : base(options) { }

  public DbSet<Todo> Todos => Set<Todo>();
}