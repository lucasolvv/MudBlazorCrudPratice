using Microsoft.EntityFrameworkCore;
using MUDCRUD.Components.Domain;
namespace MUDCRUD.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Employee> Employees { get; set; }
    }
}
