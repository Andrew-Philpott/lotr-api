using System.ComponentModel.DataAnnotations;

namespace Lotr.Models
{
  public class UpdateCharacter
  {
    [Required]
    public int Health { get; set; }
    [Required]
    public int Attack { get; set; }
    [Required]
    public string Team { get; set; }
    [Required]
    public string Name { get; set; }
  }
}