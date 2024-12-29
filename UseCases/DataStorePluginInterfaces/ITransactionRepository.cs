using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        void Add(string sellerName, int productId, string productName, double price, int beforeQty, int soldQty);
        IEnumerable<Transaction> GetByDayAndSeller(string sellerName, DateTime date);
        IEnumerable<Transaction> Search(string sellerName, DateTime startDate, DateTime endDate);
    }
}