namespace WebApp.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId = 1, Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
            new Category { CategoryId = 2, Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
            new Category { CategoryId = 3, Name = "Confections", Description = "Desserts, candies, and sweet breads" },
            new Category { CategoryId = 4, Name = "Dairy Products", Description = "Cheeses" },
        };

        public static void AddCategory(Category category)
        {
            category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            _categories.Add(category);
        }

        public static List<Category> GetAllCategories()
        {
            return _categories;
        }

        public static Category? GetCategoryById(int id)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public static void UpdateCategory(Category category)
        {
            var existingCategory = GetCategoryById(category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
        }

        public static void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

    }
}
