using Microsoft.EntityFrameworkCore;

namespace Challenge_5_Pet_Adoption_API
{
    public class AppDbContext : DbContext
    {
        //Constructor runs automattically 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Pet> Pets {get; set;}

        public DbSet<Workers> Worker { get; set; }
    }
}