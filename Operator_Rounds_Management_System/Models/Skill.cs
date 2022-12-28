using System.ComponentModel.DataAnnotations;

namespace Operator_Rounds_Management_System.Models
{
    public class Skill
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "Your {0} cannot be longer than {1} or shorter than {2} characters."), MinLength(2)]
        public string? Name { get; set; }


        // Virtual


        public virtual ICollection<Round> Rounds { get; set; } = new HashSet<Round>();

        public virtual ICollection<AppUser>? QualifiedOperators { get; set; } = new HashSet<AppUser>();
    }
}
