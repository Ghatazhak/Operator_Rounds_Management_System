using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Operator_Rounds_Management_System.Models;

namespace Operator_Rounds_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Round> Rounds { get; set; } = default!;
        public virtual DbSet<Check> Checks { get; set; } = default!;

    }
}