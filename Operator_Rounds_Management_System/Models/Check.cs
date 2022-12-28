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


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Time Completed")]
        public DateTime? Completed { get; set; }

        [Required]
        [Display(Name = "Equipment Condition")]
        public bool InService { get; set; }


        public string? Notes { get; set; }

        [Display(Name = "Work Order #")]
        public string? WorkOrderNumber { get; set; }

        // Virtual

        public virtual ICollection<Round> Rounds { get; set; } = new HashSet<Round>();


    }
}
