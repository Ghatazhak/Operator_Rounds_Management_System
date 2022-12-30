using System.ComponentModel.DataAnnotations;


namespace Operator_Rounds_Management_System.Models
{
    public class CheckCategory
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string? Name { get; set; }

        // Virtual
        public virtual ICollection<Check> Checks { get; set; } = new HashSet<Check>();

    }
}
