using Microsoft.EntityFrameworkCore;
using Stock.Api.Models;

namespace Stock.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Stocks> Stock { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
