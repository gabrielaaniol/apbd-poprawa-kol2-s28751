using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pop2kolokwium.Models;

[Table("Racer")]
public class Racer
{
    [Key]
    public int RacerId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    public ICollection<RaceParticipation> RaceParticipations { get; set; } 
}