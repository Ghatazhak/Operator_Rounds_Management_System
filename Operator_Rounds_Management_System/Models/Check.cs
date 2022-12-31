using System.ComponentModel.DataAnnotations;


namespace Operator_Rounds_Management_System.Models
{
    public class Check
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Time Completed")]
        [Required]
        public DateTime Completed { get; set; }

        [Display(Name = "Equipment Condition")]
        [Required]
        public bool InService { get; set; }

        [StringLength(500, ErrorMessage = "Your {0} cannot be longer than {1} or shorter than {2} characters."), MinLength(0)]
        public string? Notes { get; set; }

        [Display(Name = "Work Order #")]
        public string? WorkOrderNumber { get; set; }


        // Virtual
        public virtual ICollection<Round> Rounds { get; set; } = new HashSet<Round>();


    }
}
