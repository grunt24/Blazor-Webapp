using CoreEntities;
using UseCases.Interfaces;
using UseCases.UseCaseInterface;

namespace UseCases.Repository
{
    public class ViewCategories : IViewCategories
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewCategories(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IEnumerable<Category> Execute()
        {
            return categoryRepository.GetCategories();
        }
    }
}
