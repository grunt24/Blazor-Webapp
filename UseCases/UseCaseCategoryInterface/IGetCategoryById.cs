using CoreEntities;

namespace UseCases.UseCaseInterface
{
    public interface IGetCategoryById
    {
        Category Execute(int categoryId);
    }
}
