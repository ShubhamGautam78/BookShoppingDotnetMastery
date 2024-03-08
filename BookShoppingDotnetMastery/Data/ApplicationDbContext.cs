using BookShoppingDotnetMastery.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingDotnetMastery.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
    }
}
