namespace UseCases.UsecaseProductInterface
{
    public interface ISellProduct
    {
        void Execute(string cashierName , int productId, int qtyToSell);
    }
}