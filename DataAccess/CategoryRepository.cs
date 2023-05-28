using CoreEntities;
using System.ComponentModel.DataAnnotations;
using UseCases.Interfaces;

namespace DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public CategoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category() { CategoryId= 1, Name = "Beverage", Description = "Beverage" },
                new Category() { CategoryId= 1, Name = "Bakery", Description = "Bakery" },
                new Category() { CategoryId= 1, Name = "Meat", Description = "Meat" }
            };
        }

        public void AddCategory(Category category)
        {
            if (_categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            if(_categories != null && _categories.Count > 0)
            {
                var maxId = _categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
            
            _categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories?.FirstOrDefault(x=>x.CategoryId == categoryId);
        }

        public void DeleteCategory(int categoryId)
        {
            _categories?.Remove(GetCategoryById(categoryId));    
        }
    }
}
