namespace UseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string sellerName, int productId, int qty);
    }
}