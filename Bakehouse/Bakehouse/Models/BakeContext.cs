using Microsoft.EntityFrameworkCore;
namespace Bakehouse.Models
{
    public class BakeContext : DbContext
    {
        public DbSet<Bakery> Products { get; set; }

        public BakeContext(DbContextOptions<BakeContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
