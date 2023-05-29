using CoreEntities;

namespace UseCases.UsecaseProductInterface
{
    public interface IViewProductsByCategoryId
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}