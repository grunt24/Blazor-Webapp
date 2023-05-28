using CoreEntities;

namespace UseCases.UseCaseInterface
{
    public interface IAddCategory
    {
        void Execute(Category category);
    }
}