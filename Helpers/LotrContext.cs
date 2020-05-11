using Lotr.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lotr.Helpers
{
  public class LotrContext : DbContext
  {
    public LotrContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Character> Characters { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<Character>().HasData(
      new Character() { Id = 1, Team = "Good", Health = 20, Attack = 20, Name = "Frodo" },
      new Character() { Id = 1, Team = "Good", Health = 20, Attack = 20, Name = "Sam" },
      new Character() { Id = 1, Team = "Good", Health = 20, Attack = 40, Name = "Gandalf" },
      new Character() { Id = 1, Team = "Bad", Health = 20, Attack = 20, Name = "Orc" },
      new Character() { Id = 1, Team = "Bad", Health = 80, Attack = 80, Name = "Troll" },
      new Character() { Id = 1, Team = "Bad", Health = 2000, Attack = 300, Name = "Balrog" }
      );
    }
  }
}