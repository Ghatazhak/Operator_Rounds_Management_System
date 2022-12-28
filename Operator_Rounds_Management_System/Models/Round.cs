using System.ComponentModel.DataAnnotations;

namespace Operator_Rounds_Management_System.Models
{
    public class Round
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Round Name")]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Shift Notes")]
        public string? Notes { get; set; }



        // Virtual

        [Required]
        [Display(Name = "Operator")]
        public virtual AppUser? AppUser { get; set; }


        public virtual Skill? Skill { get; set; }

        public virtual ICollection<Check> Checks { get; set; } = new HashSet<Check>();
    }
}
