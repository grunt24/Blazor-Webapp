using CoreEntities;

namespace UseCases.UseCaseInterface
{
    public interface IViewCategories
    {
        IEnumerable<Category> Execute();
    }
}