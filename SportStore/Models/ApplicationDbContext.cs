
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace SportStore.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       

        public DbSet<Product> products { get; set; }

        public DbSet<Order> orders { get; set; }
       



    }
}
