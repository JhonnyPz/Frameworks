using Microsoft.EntityFrameworkCore;
using app.Data.Models;

namespace app.Data;

public class SQLiteContext : DbContext
{
  public SQLiteContext(DbContextOptions<SQLiteContext> options)
    : base(options)
  { }

  public DbSet<Design> Designs { get; set; }
}
