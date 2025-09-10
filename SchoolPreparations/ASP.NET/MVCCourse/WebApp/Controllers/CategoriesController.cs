using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(category);
        }

		[HttpPost]
		public IActionResult Edit(Category category)
		{
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category);
			    return RedirectToAction(nameof(Index));
            }
            return View(category);
		}

        public IActionResult Delete(int id)
		{
			CategoriesRepository.DeleteCategory(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
