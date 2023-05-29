using CoreEntities;

namespace UseCases.UsecaseProductInterface
{
    public interface IGetTodayTransaction
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}