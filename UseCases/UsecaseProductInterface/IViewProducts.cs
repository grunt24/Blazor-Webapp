using CoreEntities;

namespace UseCases.UsecaseProductInterface
{
    public interface IViewProducts
    {
        IEnumerable<Product> Execute();
    }
}