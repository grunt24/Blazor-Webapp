using CoreEntities;

namespace UseCases.UsecaseProductInterface
{
    public interface IAddProduct
    {
        void Execute(Product product);
    }
}