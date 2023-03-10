using Microsoft.AspNetCore.Identity;
using Operator_Rounds_Management_System.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Operator_Rounds_Management_System.Models
{
    public class AppUser : IdentityUser
    {


        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "Your {0} cannot be longer than {1} or shorter than {2} characters."), MinLength(2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Your {0} cannot be longer than {1} or shorter than {2} characters."), MinLength(2)]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }




        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";




        // Virtual
        public virtual List<Skills>? Skills { get; set; }
    }
}
