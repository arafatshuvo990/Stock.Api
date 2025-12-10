using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Models;

namespace Stock.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Stocks> Stock { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
