using CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.Interfaces;
using UseCases.UseCaseInterface;

namespace UseCases.Repository
{
    public class GetCategoryById : IGetCategoryById
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryById(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Category Execute(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }
    }
}
