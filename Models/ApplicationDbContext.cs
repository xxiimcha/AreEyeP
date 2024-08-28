using Microsoft.EntityFrameworkCore;

namespace AreEyeP.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BurialApplication> BurialApplications { get; set; } // Add this line
    }
}
