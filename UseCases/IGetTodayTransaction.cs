using CoreEntities;

namespace UseCases
{
    public interface IGetTodayTransaction
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}