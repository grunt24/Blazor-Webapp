using CoreEntities;

namespace UseCases.UsecaseProductInterface
{
    public interface IGetProductById
    {
        Product Execute(int productId);
    }
}