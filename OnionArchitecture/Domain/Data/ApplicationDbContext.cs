using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Models;

namespace OnionArchitecture.Domain.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department>Departments { get; set; }
    }
}
