using CoreEntities;

namespace UseCases
{
    public interface IGetTransactions
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}