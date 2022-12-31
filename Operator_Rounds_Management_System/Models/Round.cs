using Operator_Rounds_Management_System.Enums;
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


        [Display(Name = "Round Description")]
        [Required]
        public string? Description { get; set; }

        [Display(Name = "Shift Notes")]
        public string? Notes { get; set; }


        public Skills Skill { get; set; }


        // Virtual
        public virtual AppUser Operator { get; set; } = null!;

        public virtual ICollection<Check> Checks { get; set; } = new HashSet<Check>();
    }
}
