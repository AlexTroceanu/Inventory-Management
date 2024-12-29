using CoreBusiness;

namespace UseCases
{
    public interface ISearchTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string sellerName, DateTime startDate, DateTime endDate);
    }
}