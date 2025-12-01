using Microsoft.EntityFrameworkCore;
using ProjectUniconnect.Models;

namespace ProjectUniconnect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employer> Employers { get; set; }
    }
}
