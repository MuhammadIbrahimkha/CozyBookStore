using CozyBookStore2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CozyBookStore2.Data
{
    public class ApplicationDb : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> option): base (option)
        {
            
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
