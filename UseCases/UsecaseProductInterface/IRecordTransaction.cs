namespace UseCases.UsecaseProductInterface
{
    public interface IRecordTransaction
    {
        void Execute(string cashierName, int productId, int qty);
    }
}