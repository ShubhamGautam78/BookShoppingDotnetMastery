using BookShoppingDotnetMastery.Data;
using BookShoppingDotnetMastery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingDotnetMastery.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
           IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
    }
}
