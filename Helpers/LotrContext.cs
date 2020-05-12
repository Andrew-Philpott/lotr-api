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
      new Character() { Id = 1, Team = "Good", Armor = 1, Magic = 0, Health = 20, Attack = 20, Name = "Frodo" },
      new Character() { Id = 2, Team = "Good", Armor = 1, Magic = 0, Health = 20, Attack = 20, Name = "Sam" },
      new Character() { Id = 3, Team = "Good", Armor = 1, Magic = 5, Health = 20, Attack = 40, Name = "Gandalf" },
      new Character() { Id = 4, Team = "Bad", Armor = 4, Magic = 0, Health = 20, Attack = 20, Name = "Orc" },
      new Character() { Id = 5, Team = "Bad", Armor = 3, Magic = 0, Health = 80, Attack = 80, Name = "Troll" },
      new Character() { Id = 6, Team = "Bad", Armor = 6, Magic = 3, Health = 2000, Attack = 300, Name = "Balrog" }
      );
    }
  }
}