using BookShopping.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopping.DataAccess.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
    }
}
