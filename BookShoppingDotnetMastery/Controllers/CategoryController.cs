using BookShopping.DataAccess.Data;
using BookShopping.DataAccess.Repository.IRepository;
using BookShopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingDotnetMastery.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryrep;

        public CategoryController(ICategoryRepository categoryrep)
        {
           _categoryrep = categoryrep;
        }
        public IActionResult Index()
        {
           IEnumerable<Category> categories =  _categoryrep.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj) 
        {
            try
            {
                //if(obj.Name == obj.DisplayOrder.ToString())
                //{
                //    ModelState.AddModelError("name", "Display order and Category could not be the same");
                //}
                //if (obj.Name != null && obj.Name.ToLower() == "test")
                //{
                //    ModelState.AddModelError("", "Test is Invalid input");

                //}
                if (ModelState.IsValid)
                {
                    _categoryrep.Add(obj);
                    _categoryrep.Save();
                    TempData["success"] = "Category Saved Successfully";
                    return RedirectToAction("Index", "Category");
                }
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            return View("Create");
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? category = new Category();
            category = _categoryrep.Get(x=> x.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryrep.Update(obj);
                    _categoryrep.Save();
                    TempData["success"] = "Category Updated Successfully";
                    return RedirectToAction("Index", "Category");
                }
            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            return View("Create");
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? category = new Category();
            category = _categoryrep.Get(x => x.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {
            try
            {
                Category? category = _categoryrep.Get(x => x.Id == Id);
                if (category == null)
                {
                    return NotFound();
                }
                _categoryrep.Remove(category);
                _categoryrep.Save();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToAction("Index", "Category");

            }
            catch (Exception ex)
            {
                Convert.ToString(ex.Message);
            }
            return View();
        }
    }
}
