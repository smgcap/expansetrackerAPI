using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace expansetrackerAPI.Models
{
    public class ExpanseDbContext:DbContext
    {
        public ExpanseDbContext(DbContextOptions<ExpanseDbContext> options):base(options)
        {
            
        }
        public DbSet<UserRegistraion> userRegistraions { get; set; }
    }
}
