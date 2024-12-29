namespace UseCases
{
    public interface ISellProductUseCase
    {
        void Execute(string sellerName, int productId, int qtyToSell);
    }
}