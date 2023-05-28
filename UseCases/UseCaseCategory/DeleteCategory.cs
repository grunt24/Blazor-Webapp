using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.UseCaseInterface;

namespace UseCases.Repository
{
    public class DeleteCategory : IDeleteCategory
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategory(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Delete(int categoryId)
        {
            categoryRepository.DeleteCategory(categoryId);
        }
    }
}
